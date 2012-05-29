namespace Brandy.Core
{
    using System.Net.Mail;

    public class DefaultMailSender : IMailSender
    {
        public void SendMail(string to, string subject, string body)
        {
            using (var client = new SmtpClient())
            using (var message = new MailMessage())
            {
                message.To.Add(to);
                message.Subject = subject;
                message.Body = body;
                client.Send(message);
            }
        }
    }
}
