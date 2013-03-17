namespace Brandy.EntityFramework
{
    using System.Data.Entity;
    using Core;

    public abstract class EntityFrameworkRepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly DbContext context;

        protected EntityFrameworkRepositoryBase(DbContext context)
        {
            this.context = context;
        }

        private DbSet<TEntity> Set
        {
            get { return context.Set<TEntity>(); }
        }

        public void Add(TEntity entity)
        {
            Set.Add(entity);
        }

        public void Remove(TEntity entity)
        {
            Set.Remove(entity);
        }

        public TEntity Get(int id)
        {
            return Set.Find(id);
        }
    }
}