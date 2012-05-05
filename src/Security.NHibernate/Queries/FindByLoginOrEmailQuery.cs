namespace Brandy.Security.NHibernate.Queries
{
    using System.Linq;

    using Brandy.NHibernate;
    using Brandy.Security.Criteria;
    using Brandy.Security.Entities;

    public class FindByLoginOrEmailQuery : NHibernateLinqQueryBase<User, FindByLoginOrEmail>
    {
        public FindByLoginOrEmailQuery(ILinqProvider linqProvider)
            : base(linqProvider)
        {
        }

        public override User Ask(FindByLoginOrEmail criterion)
        {
            return Query<User>()
                .SingleOrDefault(x => x.Login == criterion.LoginOrEmail || x.EMail == criterion.LoginOrEmail);
        }
    }
}
