using FCG_NOTIFICATIONSAPI.Interfaces.Services;
using System.Net;
using System.Net.Mail;

namespace FCG_NOTIFICATIONSAPI.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendAsync(string to, string subject, string body)
        {
            var smtpClient = new SmtpClient
            {
                Host = _config["Email:Host"],
                Port = int.Parse(_config["Email:Port"]),
                EnableSsl = true,
                Credentials = new NetworkCredential(
                    _config["Email:User"],
                    _config["Email:Password"])
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_config["Email:From"]),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            mailMessage.To.Add(to);

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}
