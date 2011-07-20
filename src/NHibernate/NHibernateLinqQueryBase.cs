namespace Brandy.Core
{
    using System.Linq;
    using NHibernate;

    public abstract class NHibernateLinqQueryBase<TResult, TCriterion> : IQuery<TResult, TCriterion>
        where TCriterion : ICriterion
    {
        public INHibernateLinqProvider LinqProvider { get; set; }

        protected IQueryable<T> Query<T>()
        {
            return LinqProvider.Query<T>();
        }

        public abstract TResult Ask(TCriterion criterion);
    }
}