namespace Brandy.Security.Web.Forms.Metadata
{
    using MvcExtensions;

    public class SignInMetadata : ModelMetadataConfiguration<SignIn>
    {
        public SignInMetadata()
        {
            Configure(x => x.LoginOrEmail)
                .DisplayName("Имя пользователя")
                .Required("Необходимо указать имя пользователя");

            Configure(x => x.Password)
                .DisplayName("Пароль")
                .Required("Необходимо указать пароль")
                .AsPassword();

            Configure(x => x.RememberMe)
                .DisplayName("Запомнить меня");
        }
    }
}