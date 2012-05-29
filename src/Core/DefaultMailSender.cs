namespace Brandy.Core
{
    using System.Net.Mail;

    public class DefaultMailSender : IMailSender
    {
        public void SendMail(string @from, string to, string subject, string body)
        {
            using (var client = new SmtpClient())
            {
                client.Send(from, to, subject, body);
            }
        }
    }
}