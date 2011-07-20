using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace Brandy.NHibernate.Conventions
{
    public class HasManyConvention : IHasManyConvention, IHasManyToManyConvention
    {
        public void Apply(IOneToManyCollectionInstance instance)
        {
            instance.Access.ReadOnlyPropertyThroughCamelCaseField();
            instance.Cascade.AllDeleteOrphan();
            instance.Inverse();
            instance.AsSet();
            instance.BatchSize(25);
        }

        public void Apply(IManyToManyCollectionInstance instance)
        {
            instance.Access.ReadOnlyPropertyThroughCamelCaseField();
            instance.Cascade.AllDeleteOrphan();
            instance.AsSet();
            instance.BatchSize(25);
        }
    }
}
