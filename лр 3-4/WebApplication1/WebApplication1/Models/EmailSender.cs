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
            var emailMessage = new MailMessage(new MailAddress("myTest1mail@mail.ru", "myTest1mail@mail.ru"), new MailAddress(email))
            {
                Subject =subject,
                Body=htmlMessage,
                IsBodyHtml=true
            };
            var smtpClient = new SmtpClient("smtp.mail.ru")
            {
                Credentials = new NetworkCredential("myTest1mail@mail.ru", "Parol_1"),
                EnableSsl = true
            };
            try
            {
                await smtpClient.SendMailAsync(emailMessage);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception caught in SendEmailAsync(): {0}", ex.ToString());
            }
        }
    }
}
