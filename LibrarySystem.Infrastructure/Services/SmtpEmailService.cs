using LibrarySystem.Core.Common.Interfaces;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Options;
using LibrarySystem.Core.Settings;

namespace LibrarySystem.Infrastructure.Services
{
    public class SmtpEmailService : IEmailService
    {
        private readonly SmtpSettings _smtpSettings;

        public SmtpEmailService(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }
        public async Task SendEmailAsync(string to, string subject, string body)
        {

            using var smtpClient = new SmtpClient(_smtpSettings.Host)
            {
                Port = _smtpSettings.Port,
                Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password),
                EnableSsl = _smtpSettings.EnableSsl,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false
            };

            var mailMessage = new MailMessage(_smtpSettings.Username, to, subject, body)
            {
                IsBodyHtml = true
            };
            try
            {
                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao enviar e-mail.", ex);
            }
         
        }
    }
}
