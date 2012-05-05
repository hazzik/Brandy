namespace Brandy.Web
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Web;
    using System.Web.Caching;
    using System.Web.Compilation;
    using System.Web.Hosting;

    public class EmbeddedResourceVirtualPathProvider : VirtualPathProvider
    {
        private static readonly IDictionary<string, string> NamespaceMappings = new Dictionary<string, string>();

        private static IEnumerable<AssemblyResourceNamePair> _pairs;

        private readonly ConcurrentDictionary<string, NestedVirtualFile> cache = new ConcurrentDictionary<string, NestedVirtualFile>(StringComparer.OrdinalIgnoreCase);

        private static IEnumerable<AssemblyResourceNamePair> AssemblyResourceNamePairs
        {
            get { return _pairs ?? (_pairs = GetAssemblyResourceNamePairs().ToList()); }
        }

        public void AddNamespaceMapping(string path, string toNamespace)
        {
            NamespaceMappings.Add(path, toNamespace);
        }

        public override bool FileExists(string virtualPath)
        {
            if (base.FileExists(virtualPath))
            {
                return true;
            }

            var resource = Cache(virtualPath);
            return resource != null && !resource.IsDirectory;
        }

        public override CacheDependency GetCacheDependency(string virtualPath, IEnumerable virtualPathDependencies, DateTime utcStart)
        {
            if (base.FileExists(virtualPath))
            {
                return base.GetCacheDependency(virtualPath, virtualPathDependencies, utcStart);
            }

            NestedVirtualFile virtualFile;
            if (!cache.TryGetValue(virtualPath, out virtualFile) || virtualFile == null)
            {
                return null;
            }

            return virtualFile.Dependency;
        }

        public override VirtualFile GetFile(string virtualPath)
        {
            return base.FileExists(virtualPath) ? base.GetFile(virtualPath) : Cache(virtualPath);
        }

        public void RemoveNamespaceMapping(string path)
        {
            if (!NamespaceMappings.Remove(path))
            {
                return;
            }

            foreach (var item in (from key in cache.Keys
                                  where key.StartsWith(path)
                                  select key))
            {
                NestedVirtualFile value;
                if (cache.TryRemove(item, out value) && value != null)
                {
                    value.Dependency.Removed();
                }
            }
        }

        private static IEnumerable<AssemblyResourceNamePair> GetAssemblyResourceNamePairs()
        {
            return from assembly in GetReferencedAssemblies()
                   from name in assembly.GetManifestResourceNames()
                   select new AssemblyResourceNamePair
                              {
                                  Assembly = assembly,
                                  Name = name
                              };
        }

        private static NestedVirtualFile GetNestedVirtualFile(string virtualPath)
        {
            var mappings = GetResourceMappings(virtualPath);
            if (mappings == null || !mappings.Any())
            {
                return null;
            }

            return AssemblyResourceNamePairs.Where(x => mappings.Contains(x.Name))
                .Select(pair => new NestedVirtualFile(virtualPath, pair.Assembly, pair.Name))
                .FirstOrDefault();
        }

        private static IEnumerable<Assembly> GetReferencedAssemblies()
        {
            return BuildManager.GetReferencedAssemblies().Cast<Assembly>();
        }

        private static ISet<string> GetResourceMappings(string virtualPath)
        {
            var searchPath = GetSearchPath(virtualPath);
            var enumerable = from m in NamespaceMappings
                             where searchPath.StartsWith(m.Key, StringComparison.OrdinalIgnoreCase)
                             select m.Value + searchPath.Substring(m.Key.Length).Replace("/", ".");
            return new HashSet<string>(enumerable, StringComparer.OrdinalIgnoreCase);
        }

        private static string GetSearchPath(string virtualPath)
        {
            var searchPath = virtualPath.TrimStart('~');
            var applicationPath = HttpContext.Current.Request.ApplicationPath;
            if (HttpContext.Current != null && applicationPath != null && searchPath.StartsWith(applicationPath, StringComparison.OrdinalIgnoreCase))
            {
                searchPath = searchPath.Substring(applicationPath.Length);
            }
            if (!searchPath.StartsWith("/"))
            {
                searchPath = "/" + searchPath;
            }
            return searchPath;
        }

        private NestedVirtualFile Cache(string virtualPath)
        {
            return cache.GetOrAdd(virtualPath, arg => GetNestedVirtualFile(virtualPath));
        }

        private class AssemblyResourceNamePair
        {
            public Assembly Assembly { get; set; }
            public string Name { get; set; }
        }

        private class NestedCacheDependency : CacheDependency
        {
            /// <summary>
            ///   <para>Removed</para>
            /// </summary>
            public void Removed()
            {
                NotifyDependencyChanged(this, EventArgs.Empty);
            }
        }

        private class NestedVirtualFile : VirtualFile
        {
            private readonly Assembly assembly;
            private readonly string name;

            public NestedVirtualFile(string virtualPath, Assembly assembly, string name)
                : base(virtualPath)
            {
                this.assembly = assembly;
                this.name = name;
            }

            public NestedCacheDependency Dependency { get; private set; }

            public override Stream Open()
            {
                return assembly.GetManifestResourceStream(name);
            }
        }
    }
}
