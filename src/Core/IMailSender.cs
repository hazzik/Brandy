namespace Brandy.Core
{
    public interface IMailSender
    {
        void SendMail(string from, string to, string subject, string body);
    }
}
