namespace Brandy.Security.Windsor
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    using Web.Services;
    using Web.Services.Impl;

    public class SecurityInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IAuthenticationService>().ImplementedBy<FormsAuthenticationService>().LifeStyle.Transient,
                               Component.For<IContextUserProvider>().ImplementedBy<ContextUserProvider>().LifeStyle.Transient);
        }
    }
}
