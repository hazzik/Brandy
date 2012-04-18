namespace Brandy.NHibernate.Conventions
{
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.Instances;

    public class ForeignKeyConstraintNameConvention : IReferenceConvention, IHasManyToManyConvention, IJoinedSubclassConvention, IJoinConvention, ICollectionConvention
    {
        public void Apply(ICollectionInstance instance)
        {
            var constraint = NameConventions.GetForeignKeyConstraintName(instance.ChildType.Name, instance.EntityType.Name);
            instance.Key.ForeignKey(constraint);
        }

        public void Apply(IManyToManyCollectionInstance instance)
        {
            var childConstraint = NameConventions.GetForeignKeyConstraintName(instance.TableName, instance.ChildType.Name);
            instance.Relationship.ForeignKey(childConstraint);

            var childConstraint2 = NameConventions.GetForeignKeyConstraintName(instance.TableName, instance.EntityType.Name);
            instance.Key.ForeignKey(childConstraint2);
        }

        public void Apply(IJoinInstance instance)
        {
            //Type type = instance.EntityType;
            //string constraint = GetConstraintName(type.Name, ((Member) null).Name);
            //instance.Key.ForeignKey(constraint);
        }

        public void Apply(IJoinedSubclassInstance instance)
        {
            var type = instance.EntityType;
            var baseType = type.BaseType;
            if (baseType == null) return;

            var constraintName = NameConventions.GetForeignKeyConstraintName(type.Name, baseType.Name);
            instance.Key.ForeignKey(constraintName);
        }

        public void Apply(IManyToOneInstance instance)
        {
            var type = instance.EntityType;
            var member = instance.Property;

            var columnName = NameConventions.GetForeignKeyConstraintName(type.Name, member.Name);
            instance.ForeignKey(columnName);
        }
    }
}
