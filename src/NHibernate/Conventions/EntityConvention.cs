using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace Brandy.NHibernate.Conventions
{
    public class EntityConvention : IClassConvention, IJoinedSubclassConvention
	{
        public void Apply(IClassInstance instance)
		{
			string tableName = NameConventions.GetTableName(instance.EntityType);

			instance.Table(tableName);
		    instance.BatchSize(25);
		}

        public void Apply(IJoinedSubclassInstance instance)
		{
			string tableName = NameConventions.GetTableName(instance.EntityType);

			instance.Table(tableName);
            instance.BatchSize(25);
		}
	}
}