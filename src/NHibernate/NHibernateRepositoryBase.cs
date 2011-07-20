namespace Brandy.NHibernate
{
    using Core;
    using global::NHibernate;

    public abstract class NHibernateRepositoryBase<TEntity> : IRepository<TEntity>
    {
        private readonly ISessionProvider sessionProvider;

        protected NHibernateRepositoryBase(ISessionProvider sessionProvider)
        {
            this.sessionProvider = sessionProvider;
        }

        protected ISession Session
        {
            get { return sessionProvider.CurrentSession; }
        }

        #region IRepository<TEntity> Members

        public virtual void Add(TEntity entity)
        {
            Session.Save(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            Session.Delete(entity);
        }

        public virtual TEntity Get(int id)
        {
            return Session.Get<TEntity>(id);
        }

        #endregion
    }
}
