namespace Brandy.Core
{
    public interface IQueryBuilder
    {
        IQueryFor<T> For<T>();
    }
}