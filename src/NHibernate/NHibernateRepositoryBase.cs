namespace Brandy.NHibernate
{
    using Core;
    using global::NHibernate;

    public abstract class NHibernateRepositoryBase<TEntity> : IRepository<TEntity>
    {
        public ISessionProvider SessionProvider { get; set; }

        protected ISession Session
        {
            get { return SessionProvider.CurrentSession; }
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
