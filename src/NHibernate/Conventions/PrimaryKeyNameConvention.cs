using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace Brandy.NHibernate.Conventions
{
    public class PrimaryKeyNameConvention : IIdConvention
	{
        public void Apply(IIdentityInstance instance)
		{
			string columnName = NameConventions.GetPrimaryKeyColumnName(instance.EntityType);

			instance.Column(columnName);
		}
	}
}