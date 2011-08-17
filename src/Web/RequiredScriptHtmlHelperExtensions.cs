namespace Brandy.Web
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;

    public static class RequiredScriptHtmlHelperExtensions
    {
        public static string RequireScript(this HtmlHelper html, string path)
        {
            RequiredScripts(html).Add(path);
            return string.Empty;
        }

        public static string RequireScript(this HtmlHelper html, string path1, string path2)
        {
            ISet<string> requiredScripts = RequiredScripts(html);
            requiredScripts.Add(path1);
            requiredScripts.Add(path2);
            return string.Empty;
        }

        public static string RequireScript(this HtmlHelper html, string path1, string path2, string path3)
        {
            ISet<string> requiredScripts = RequiredScripts(html);
            requiredScripts.Add(path1);
            requiredScripts.Add(path2);
            requiredScripts.Add(path3);
            return string.Empty;
        }

        public static string RequireScript(this HtmlHelper html, params string[] paths)
        {
            ISet<string> requiredScripts = RequiredScripts(html);
            foreach (string path in paths)
            {
                requiredScripts.Add(path);
            }
            return string.Empty;
        }

        public static IHtmlString OutputRequiredScripts(this HtmlHelper html)
        {
            var sb = new StringBuilder();
            var requiredScripts = RequiredScripts(html);
            foreach (string script in requiredScripts)
            {
                sb.AppendFormat(@"<script src=""{0}"" type=""text/javascript""></script>", script);
            }
            requiredScripts.Clear();
            return MvcHtmlString.Create(sb.ToString());
        }

        private static ISet<string> RequiredScripts(HtmlHelper html)
        {
            TempDataDictionary tempData = html.ViewContext.TempData;
            const string requredScripts = "BrandyRequredScripts";
            ISet<string> requiredScripts = (ISet<String>) tempData[requredScripts] ?? new HashSet<string>();
            tempData[requredScripts] = requiredScripts;
            return requiredScripts;
        }
    }
}
