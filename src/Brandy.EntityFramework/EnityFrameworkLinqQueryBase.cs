namespace Brandy.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Core;

    public abstract class EnityFrameworkLinqQueryBase<TResult, TCriterion> : IQuery<TResult, TCriterion> where TCriterion : ICriterion
    {
        private readonly DbContext context;

        protected EnityFrameworkLinqQueryBase(DbContext context)
        {
            this.context = context;
        }

        public abstract TResult Ask(TCriterion criterion);

        protected IQueryable<T> Query<T>() where T : class
        {
            return context.Set<T>();
        }
    }
}
