namespace Brandy.Core
{
    public interface IQueryBuilder
    {
        IQueryBuilderWithPart<T> For<T>();
    }
}