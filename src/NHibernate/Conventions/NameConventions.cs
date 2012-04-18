namespace Brandy.NHibernate.Conventions
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public static class NameConventions
    {
        public static string GetTableName(Type type)
        {
            return ReplaceCamelCaseWithUnderscore(type.Name).ToUpper();
        }

        public static string GetSequenceName(Type type)
        {
            return JoinParts(type.Name, "SEQ");
        }

        public static string GetPrimaryKeyColumnName(Type type)
        {
            return JoinParts(type.Name, "ID");
        }

        public static string ReplaceCamelCaseWithUnderscore(string name)
        {
            return Regex.Replace(name, "([a-z](?=[A-Z])|[A-Z](?=[A-Z][a-z]))", "$1_");
        }

        public static string GetForeignKeyConstraintName(string child, string parent)
        {
            return JoinParts(new[] {"FK", child, parent});
        }

        public static string GetManyToManyForeignKeyConstraintName(string child, string parent, string reference)
        {
            return JoinParts(new[] {"FK", child, parent, reference});
        }

        public static string JoinParts(params string[] parts)
        {
            return string.Join("_", parts.Select(ReplaceCamelCaseWithUnderscore)).ToUpper();
        }

        public static string Quote(string value)
        {
            return string.Format("`{0}`", value);
        }
    }
}

