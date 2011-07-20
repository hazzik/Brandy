namespace Brandy.NHibernate
{
    using System.Linq;

    public interface INHibernateLinqProvider
    {
        IQueryable<T> Query<T>();
    }
}
