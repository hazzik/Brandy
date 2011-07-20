namespace Brandy.NHibernate
{
    using System.Linq;
    using global::NHibernate.Linq;

    public sealed class NHibernateLinqProvider : ILinqProvider
    {
        private readonly ISessionProvider sessionProvider;

        public NHibernateLinqProvider(ISessionProvider sessionProvider)
        {
            this.sessionProvider = sessionProvider;
        }

        #region INHibernateLinqProvider Members

        public IQueryable<T> Query<T>()
        {
            return sessionProvider.CurrentSession.Query<T>();
        }

        #endregion
    }
}