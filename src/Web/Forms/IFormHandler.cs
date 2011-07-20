namespace Brandy.Web.Forms
{
	public interface IFormHandler<in TForm> where TForm : IForm
	{
		void Handle(TForm form);
	}
}