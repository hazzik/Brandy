namespace Brandy.Security.Web.Forms.Handlers
{
    using Brandy.Web.Forms;

    using Services;

    public class SignOutHandler : IFormHandler<SignOut>
    {
        private readonly IAuthenticationService service;

        public SignOutHandler(IAuthenticationService service)
        {
            this.service = service;
        }

        public virtual void Handle(SignOut command)
        {
            service.SignOut();
        }
    }
}
