namespace Brandy.Security.Web.Forms.Metadata
{
    using MvcExtensions;

    public class SignUpMetadata : ModelMetadataConfiguration<SignUp>
    {
        public SignUpMetadata()
        {
            Configure(x => x.Login)
                .DisplayName("Имя пользователя")
                .Required("Необходимо указать имя пользователя");

            Configure(x => x.Email)
                .DisplayName("Адрес электронной почты")
                .Required("Необходимоуказать адрес электронной почты")
                .AsEmail();

            Configure(x => x.Password)
                .DisplayName("Пароль")
                .Required("Необходимо указать пароль")
                .MinimumLength(6, " Длина пароля должна быть не меньше 6 символов")
                .AsPassword();

            Configure(x => x.ConfirmPassword)
                .DisplayName("Пароль еще раз")
                .Required("Необходимо указать подтверждение пароля")
                .AsPassword()
                .Compare("Password", "Пароль и подвтерждение пароля должны совпадать");
        }
    }
}