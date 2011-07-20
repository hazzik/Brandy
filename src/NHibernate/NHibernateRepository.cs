namespace Brandy.NHibernate
{
    public sealed class NHibernateRepository<TEntity> : NHibernateRepositoryBase<TEntity>
    {
        public NHibernateRepository(ISessionProvider sessionProvider) : base(sessionProvider)
        {
        }
    }
}
