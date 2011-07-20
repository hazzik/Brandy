namespace Brandy.Core
{
    public interface IQueryBuilderWithPart<out T>
    {
        T With<TCriterion>(TCriterion criterion) where TCriterion : ICriterion;
    }
}