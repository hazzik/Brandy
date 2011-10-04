namespace Brandy.Core
{
    public class QueryFor<T> : IQueryFor<T>
    {
        private readonly IQueryFactory queryFactory;

        public QueryFor(IQueryFactory queryFactory)
        {
            this.queryFactory = queryFactory;
        }

        public T With<TCriterion>(TCriterion criterion) where TCriterion : ICriterion
        {
            return queryFactory.Create<T, TCriterion>().Ask(criterion);
        }
    }
}