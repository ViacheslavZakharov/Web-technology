using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //throw new NotImplementedException();
            var emailMessage = new MailMessage(new MailAddress("v_zaharov97@mail.ru", "v_zaharov97@mail.ru"), new MailAddress(email))
            {
                Subject =subject,
                Body=htmlMessage,
                IsBodyHtml=true
            };
            var smtpClient = new SmtpClient("smtp.mail.ru")
            {
                Credentials = new NetworkCredential("v_zaharov97@mail.ru", "djudoist_victoria"),
                EnableSsl = true
            };
            try
            {
                await smtpClient.SendMailAsync(emailMessage);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception caught in CreateTestMessage4(): {0}", ex.ToString());
            }
        }
    }
}
