namespace Brandy.Security.Web.Forms.Handlers
{
    using System;

    using Brandy.Core;
    using Brandy.Security.Criteria;
    using Brandy.Security.Entities;
    using Brandy.Web.Forms;

    using Services;

    public class SignUpHandler : IFormHandler<SignUp>
    {
        private readonly IQueryBuilder query;
        private readonly IAuthenticationService service;
        private readonly IRepository<User> userRepository;

        public SignUpHandler(IAuthenticationService service, IRepository<User> userRepository, IQueryBuilder query)
        {
            this.service = service;
            this.userRepository = userRepository;
            this.query = query;
        }

        public virtual void Handle(SignUp command)
        {
            var part = query.For<User>();
            var rowCount = part.With(new FindByLoginOrEmail {LoginOrEmail = command.Login}) ??
                           part.With(new FindByLoginOrEmail {LoginOrEmail = command.Email});

            if (rowCount != null)
                throw new ApplicationException(
                    "В базе уже существует пользователь с таким именем или адресом электронной почты");

            var user = new User {EMail = command.Email, Login = command.Login};
            user.SetPassword(command.Password);
            userRepository.Add(user);

            service.SignIn(user, false);
        }
    }
}
