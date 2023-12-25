using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using ExamMaster.Application.Common.Model;
using ExamMaster.Application.Contracts;


namespace ExamMaster.Service.Emails
{
    public class EmailService :IEmailService
    {
        private readonly EmailSetting _mailSettings;
        public EmailService(IOptions<EmailSetting> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
        public async Task SendEmailAsync(string email, string subject, string body)
        {
            var message = new MailMessage()
            {
                From = new MailAddress(_mailSettings.Email!, _mailSettings.DisplayName),

                Body = body,
                Subject = subject,
                IsBodyHtml = true
            };

            message.To.Add(email);

            SmtpClient smtpClient = new SmtpClient(_mailSettings.Host)
            {
                Port = _mailSettings.Port,
                Credentials = new NetworkCredential(_mailSettings.Email, _mailSettings.Password),
                EnableSsl = true
            };

            await  smtpClient.SendMailAsync(message);
            smtpClient.Dispose();
        }


    }
}
