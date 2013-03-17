namespace Brandy.EntityFramework
{
    using System.Data.Entity;

    public class EntityFrameworkRepository<TEntity> : EntityFrameworkRepositoryBase<TEntity> 
        where TEntity : class
    {
        public EntityFrameworkRepository(DbContext context)
            : base(context)
        {
        }
    }
}