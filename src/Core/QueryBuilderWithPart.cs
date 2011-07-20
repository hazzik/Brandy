namespace Brandy.Core
{
    public class QueryBuilderWithPart<T> : IQueryBuilderWithPart<T>
    {
        private readonly IQueryFactory queryFactory;

        public QueryBuilderWithPart(IQueryFactory queryFactory)
        {
            this.queryFactory = queryFactory;
        }

        public T With<TCriterion>(TCriterion criterion) where TCriterion : ICriterion
        {
            return queryFactory.Create<T, TCriterion>().Ask(criterion);
        }
    }
}