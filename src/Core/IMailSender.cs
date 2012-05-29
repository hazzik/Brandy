namespace Brandy.Core
{
    public interface IMailSender
    {
        void SendMail(string to, string subject, string body);
    }
}
