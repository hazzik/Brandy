namespace Brandy.Core
{
    using NHibernate;
    using global::NHibernate;

    public abstract class NHibernateSessionQueryBase<TResult, TCriterion> : IQuery<TResult, TCriterion>
        where TCriterion : ICriterion
    {
        public ISessionProvider SessionProvider { get; set; }

        protected ISession Session
        {
            get { return SessionProvider.CurrentSession; }
        }

        public abstract TResult Ask(TCriterion criterion);
    }
}
