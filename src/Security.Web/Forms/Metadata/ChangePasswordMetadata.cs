namespace Brandy.Security.Web.Forms.Metadata
{
    using MvcExtensions;

    public class ChangePasswordMetadata : ModelMetadataConfiguration<ChangePassword>
    {
        public ChangePasswordMetadata()
        {
            Configure(x => x.OldPassword)
                .DisplayName("Текущий пароль")
                .Required("Необходимо указать текущий пароль")
                .AsPassword();

            Configure(x => x.NewPassword)
                .DisplayName("Новый пароль")
                .Required("Необходимо указать новый пароль")
                .MinimumLength(6, " Длина пароля должна быть не меньше 6 символов")
                .AsPassword();

            Configure(x => x.ConfirmPassword)
                .DisplayName("Пароль еще раз")
                .Required("Необходимо указать подтверждение пароля")
                .Compare("NewPassword", "Пароль и подвтерждение пароля должны совпадать")
                .AsPassword()                                                            ;
        }
    }
}