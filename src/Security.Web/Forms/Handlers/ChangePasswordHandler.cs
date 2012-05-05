namespace Brandy.Security.Web.Forms.Handlers
{
    using System;

    using Brandy.Web.Forms;

    using Services;

    public class ChangePasswordHandler : IFormHandler<ChangePassword>
    {
        private readonly IContextUserProvider contextUserProvider;

        public ChangePasswordHandler(IContextUserProvider contextUserProvider)
        {
            this.contextUserProvider = contextUserProvider;
        }

        public virtual void Handle(ChangePassword command)
        {
            var user = contextUserProvider.ContextUser();

            if (user == null || !(user.Password.Check(command.OldPassword)))
                throw new ApplicationException("Неправильно указан текущий пароль");

            user.SetPassword(command.NewPassword);
        }
    }
}
