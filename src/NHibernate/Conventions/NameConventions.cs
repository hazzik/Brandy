namespace Brandy.NHibernate.Conventions
{
    using System;
    using System.Text.RegularExpressions;

    public static class NameConventions
    {
        public static string GetTableName(Type type)
        {
            return ReplaceCamelCaseWithUnderscore(type.Name);
        }

        public static string GetSequenceName(Type type)
        {
            return String.Format("{0}_SEQ", GetTableName(type));
        }

        public static string GetPrimaryKeyColumnName(Type type)
        {
            return String.Format("{0}_ID", GetTableName(type));
        }

        public static string ReplaceCamelCaseWithUnderscore(string name)
        {
            return Regex.Replace(name, "([a-z](?=[A-Z])|[A-Z](?=[A-Z][a-z]))", "$1_").ToUpper();
        }

        public static string GetForeignKeyConstraintName(string child, string parent)
        {
            return String.Format("FK_{0}_{1}", ReplaceCamelCaseWithUnderscore(child), ReplaceCamelCaseWithUnderscore(parent)).ToUpper();
        }
    }
}

