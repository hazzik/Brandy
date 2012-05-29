namespace Brandy.Security.Web.Forms.Handlers
{
    using Brandy.Web.Forms;
    using Core;
    using Criteria;
    using Entities;

    public class RestorePasswordRequestHandler : IFormHandler<RestorePasswordRequest>
    {
        readonly IMailSender emailSender;
        readonly IQueryBuilder query;

        public RestorePasswordRequestHandler(IQueryBuilder query, IMailSender emailSender)
        {
            this.query = query;
            this.emailSender = emailSender;
        }

        public void Handle(RestorePasswordRequest form)
        {
            var user = query.For<User>()
                .With(new FindByLoginOrEmail {LoginOrEmail = form.LoginOrEmail});

            emailSender.SendMail(user.EMail, "Restore Password Link", "AAAAAA");
        }
    }
}
