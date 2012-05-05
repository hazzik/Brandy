namespace Brandy.Security.Web.Services
{
    using Brandy.Security.Entities;

    public interface IContextUserProvider
    {
        User ContextUser();
        User ContextUser(bool shouldThrow);
    }
}