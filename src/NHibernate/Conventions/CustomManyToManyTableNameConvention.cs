using System;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Inspections;

namespace Brandy.NHibernate.Conventions
{
    public class CustomManyToManyTableNameConvention : ManyToManyTableNameConvention
	{
		protected override string GetBiDirectionalTableName(IManyToManyCollectionInspector collection, IManyToManyCollectionInspector otherSide)
		{
			return GetTableName(collection.EntityType, otherSide.EntityType);
		}

		protected override string GetUniDirectionalTableName(IManyToManyCollectionInspector collection)
		{
			return GetTableName(collection.EntityType, collection.ChildType);
		}

		private static string GetTableName(Type entityType, Type otherSideType)
		{
		    return NameConventions.Quote(NameConventions.JoinParts(entityType.Name, otherSideType.Name));
		}
	}
}