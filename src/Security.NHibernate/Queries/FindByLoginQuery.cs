namespace Brandy.Security.NHibernate.Queries
{
    using System.Linq;

    using Brandy.NHibernate;
    using Brandy.Security.Criteria;
    using Brandy.Security.Entities;

    public class FindByLoginQuery : NHibernateLinqQueryBase<User, FindByLogin>
    {
        public FindByLoginQuery(ILinqProvider linqProvider) : base(linqProvider)
        {
        }

        public override User Ask(FindByLogin criterion)
        {
            return Query<User>().SingleOrDefault(x => x.Login == criterion.Login);
        }
    }
}
