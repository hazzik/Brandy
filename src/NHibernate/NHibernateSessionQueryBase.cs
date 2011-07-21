namespace Brandy.NHibernate
{
    using Core;
    using global::NHibernate;

    public abstract class NHibernateSessionQueryBase<TResult, TCriterion> : IQuery<TResult, TCriterion>
        where TCriterion : ICriterion
    {
        private readonly ISessionProvider sessionProvider;

        public NHibernateSessionQueryBase(ISessionProvider sessionProvider)
        {
            this.sessionProvider = sessionProvider;
        }

        protected ISession Session
        {
            get { return sessionProvider.CurrentSession; }
        }

        public abstract TResult Ask(TCriterion criterion);
    }
}
