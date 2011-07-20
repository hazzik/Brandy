namespace Brandy.NHibernate
{
    using System.Linq;

    public interface ILinqProvider
    {
        IQueryable<T> Query<T>();
    }
}
