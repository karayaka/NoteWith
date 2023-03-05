using System;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using NoteWith.Application.Services;

namespace NoteWith.Infrastructure.Services
{
	public class EmailService:IEmailService
	{
        private readonly IConfiguration config;
		public EmailService(IConfiguration _config)
		{
            config = _config;
		}

        public async Task SendEmailConfirmeMail(string email, string code)
        {
            try
            {
                var htmlBody = "<h3>Dogrulama Kodunuz: " + code + "</h3>";
                await SendEmil(email, "Email Doğrulama Kodu", htmlBody);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task SendEmil(string[] tos, string subject, string body, bool ishtmlBody = true)
        {
            //Email Bilgileri apsetting jspon dosysında kotrol edilecek!!
            try
            {
                MailMessage mail = new();
                mail.IsBodyHtml = ishtmlBody;
                foreach (var item in tos)
                {
                    mail.To.Add(item);
                }
                mail.Subject = subject;
                mail.Body = body;
                mail.From = new(config["Mail:UserName"], "Note With",System.Text.Encoding.UTF8);

                SmtpClient smtp = new();
                smtp.Credentials = new NetworkCredential(config["Mail:UserName"], config["Mail:Password"]);
                smtp.Port = 25;//sll geldiğinde değişebilir!
                smtp.EnableSsl = false;
                smtp.Host = config["Mail:Host"];
                
                await smtp.SendMailAsync(mail);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task SendEmil(string to, string subject, string body, bool ishtmlBody = true)
        {
            try
            {
               await SendEmil(new[] { to }, subject, body, ishtmlBody);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

