namespace Brandy.Security.Web.Forms
{
    using Brandy.Web.Forms;

    public class RestorePasswordRequest : IForm
    {
        public string LoginOrEmail { get; set; }
    }
}
