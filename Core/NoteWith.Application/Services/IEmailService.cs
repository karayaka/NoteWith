using System;
namespace NoteWith.Application.Services
{
	public interface IEmailService
	{
        /// <summary>
        /// email göndert tek kullaıcı
        /// </summary>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="ishtmlBody"></param>
        /// <returns></returns>
        Task SendEmil(string to, string subject, string body, bool ishtmlBody = true);
        /// <summary>
        /// email gönder çok kullanıcı
        /// </summary>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="ishtmlBody"></param>
        /// <returns></returns>
        Task SendEmil(string[] to, string subject, string body, bool ishtmlBody = true);

        //cutom teplateler ve teplate generatorler buraya gelebilir

        Task SendEmailConfirmeMail(string email, string code);
    }
}

