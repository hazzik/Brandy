namespace Brandy.Web.Forms
{
    using System;
    using System.Web.Mvc;

    public abstract class FormControllerBase : Controller
	{
		private const string ModelStateKey = "ModelState";
		private const string ValueProviderKey = "ValueProvider";

		public IFormHandlerFactory FormHandlerFactory { get; set; }

		protected ActionResult Handle<TForm>(TForm form,
											ActionResult successResult) where TForm : IForm
		{
			return Handle(form, () => successResult);
		}

		protected ActionResult Handle<TForm>(TForm form,
											 ActionResult successResult,
											 ActionResult failResult) where TForm : IForm
		{
			var urlReferrer = Request.UrlReferrer;
			return Handle(form, () => successResult, () => failResult);
		}

		protected ActionResult Handle<TForm>(TForm form,
											 Func<ActionResult> successResultGetter) where TForm : IForm
		{
			return Handle(form, successResultGetter, () => Redirect(string.Format("{0}", Request.UrlReferrer)));
		}

		protected ActionResult Handle<TForm>(TForm form,
											 Func<ActionResult> successResultGetter,
											 Func<ActionResult> failResultGetter) where TForm : IForm
		{
			if (ModelState.IsValid)
			{
				try
				{
					FormHandlerFactory.Create<TForm>().Handle(form);

					return successResultGetter();
				}
				catch (Exception e)
				{
					ModelState.AddModelError("", e.Message);
				}
			}

			TempData[ModelStateKey] = ModelState;
			TempData[ValueProviderKey] = ValueProvider; 
			return failResultGetter();
		}

		protected override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			if (TempData[ModelStateKey] != null && ModelState.Equals(TempData[ModelStateKey]) == false)
			{
				ModelState.Merge((ModelStateDictionary) TempData[ModelStateKey]);

				var valueProvider = (IValueProvider) TempData[ValueProviderKey];
				var providers = new[]
									{
										ValueProvider,
										valueProvider
									};
				var provider = new ValueProviderCollection(providers);
				ValueProvider = provider;
				//dynamic trick because TryUpdateModel is generec and does not want to update models of type object:(
				dynamic model = ViewData.Model;
				TryUpdateModel(model, provider);
			}

			base.OnActionExecuted(filterContext);
		}
	}
}
