namespace Brandy.Security.Web.Services
{
    using Brandy.Security.Entities;

    public interface IAuthenticationService
    {
        void SignIn(User user, bool createPersistentCookie);
        void SignOut();
    }
}
