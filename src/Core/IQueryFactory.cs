namespace Brandy.Core
{
    public interface IQueryFactory
    {
        IQuery<TResult, TCriterion> Create<TResult, TCriterion>() where TCriterion : ICriterion;
    }
}