namespace Brandy.Security.Web.Forms
{
    using Brandy.Web.Forms;

    public class SignUp : IForm
    {
        public string Login { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
