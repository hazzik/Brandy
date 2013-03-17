namespace Brandy.Security.Web
{
    using System.Web.Mvc;

    using Brandy.Web.Forms;

    using Forms;

    public class AccountController : FormControllerBase
    {
        public ActionResult SignIn()
        {
            if (ControllerContext.IsChildAction)
                return PartialView();
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(SignIn command, string returnUrl)
        {
            return Handle(command, GetRedirectResult(returnUrl));
        }

        [BrandyAuthorize]
        public ActionResult SignOut(SignOut command, string returnUrl)
        {
            return Handle(command, GetRedirectResult(returnUrl));
        }

        public ActionResult SignUp()
        {
            ViewBag.PasswordLength = 6;
            if (ControllerContext.IsChildAction)
                return PartialView();
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(SignUp command, string returnUrl)
        {
            return Handle(command, GetRedirectResult(returnUrl));
        }

        [BrandyAuthorize]
        public ActionResult ChangePassword()
        {
            ViewBag.PasswordLength = 6;
            if (ControllerContext.IsChildAction)
                return PartialView();
            return View();
        }

        [BrandyAuthorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePassword command)
        {
            return Handle(command, RedirectToAction("ChangePasswordSuccess"));
        }

        [BrandyAuthorize]
        public ActionResult ChangePasswordSuccess()
        {
            if (ControllerContext.IsChildAction)
                return PartialView();
            return View();
        }

        private ActionResult GetRedirectResult(string returnUrl)
        {
            returnUrl = GetReturnUrl(returnUrl);

            if (Request.IsAjaxRequest())
                return JavaScript(string.Format("(function () {{ window.location = '{0}'; }})();", returnUrl));
            
            return Redirect(returnUrl);
        }

        private string GetReturnUrl(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
                return returnUrl;

            return Url.Action("Index", "Home");
        }
    }
}
