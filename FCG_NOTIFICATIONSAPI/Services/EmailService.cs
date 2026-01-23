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
            var smtp = new SmtpClient("smtp.office365.com", 587)
            {
                EnableSsl = true, // 🔴 OBRIGATÓRIO
                UseDefaultCredentials = false, // 🔴 OBRIGATÓRIO
                Credentials = new NetworkCredential(
           "nathalia_leite_12@hotmail.com",
           "ubzackishxhkkuad" // senha de aplicativo SEM espaços
       ),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            var message = new MailMessage
            {
                From = new MailAddress("nathalia_leite_12@hotmail.com"),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            message.To.Add(to);

            await smtp.SendMailAsync(message);
        }
    }
}
