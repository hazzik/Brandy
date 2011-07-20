using NHibernate.Cfg;

namespace Brandy.NHibernate
{
    public interface INHibernateConfigurator
    {
        Configuration Configure();
    }
}