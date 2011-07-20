namespace Brandy.Core
{
    public interface IRepository<TEntity>
    {
        void Add(TEntity entity);
        void Remove(TEntity entity);
        TEntity Get(int id);
    }
}