namespace Brandy.Security.Web.Forms.Handlers
{
    using System;

    using Brandy.Core;
    using Brandy.Security.Criteria;
    using Brandy.Security.Entities;
    using Brandy.Web.Forms;

    using Services;

    public class SignInHandler : IFormHandler<SignIn>
    {
        private readonly IQueryBuilder query;
        private readonly IAuthenticationService service;

        public SignInHandler(IAuthenticationService service, IQueryBuilder query)
        {
            this.service = service;
            this.query = query;
        }

        public virtual void Handle(SignIn command)
        {
            var user = query.For<User>()
                .With(new FindByLoginOrEmail {LoginOrEmail = command.LoginOrEmail});

            if (user == null || user.Password.Check(command.Password) == false)
                throw new ApplicationException("Имя пользователя или пароль не верны");

            service.SignIn(user, command.RememberMe);
        }
    }
}