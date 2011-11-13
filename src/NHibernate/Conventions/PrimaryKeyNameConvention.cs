using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace Brandy.NHibernate.Conventions
{
    public class PrimaryKeyNameConvention : IIdConvention
	{
        public void Apply(IIdentityInstance instance)
		{
			string sequenceName = NameConventions.GetSequenceName(instance.EntityType);
			string columnName = NameConventions.GetPrimaryKeyColumnName(instance.EntityType);

			instance.Column(columnName);
		    instance.GeneratedBy.HiLo("100");
		}
	}
}