namespace Brandy.Security.Windsor
{
    using Brandy.Web.Forms;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using Core;
    using Web.Services;
    using Web.Services.Impl;

    public class SecurityInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var formHandlers = AllTypes.FromAssemblyNamed("Brandy.Security.Web")
                .BasedOn(typeof (IFormHandler<>))
                .WithService.AllInterfaces()
                .LifestyleTransient();

            var queries = AllTypes.FromAssemblyNamed("Brandy.Security.NHibernate")
                .BasedOn(typeof (IQuery<,>))
                .WithService.AllInterfaces()
                .LifestyleTransient();

            container.Register(formHandlers,
                               queries,
                               Component.For<IAuthenticationService>().ImplementedBy<FormsAuthenticationService>().LifeStyle.Transient,
                               Component.For<IContextUserProvider>().ImplementedBy<ContextUserProvider>().LifeStyle.Transient);
        }
    }
}
