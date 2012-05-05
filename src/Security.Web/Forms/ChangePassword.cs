namespace Brandy.Security.Web.Forms
{
    using Brandy.Web.Forms;

    public class ChangePassword : IForm
    {
        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

        public string ConfirmPassword { get; set; }
    }
}