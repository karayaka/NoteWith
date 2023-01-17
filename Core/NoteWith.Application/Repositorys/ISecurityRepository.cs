using System;
using NoteWith.Domain.DTOModels.SecurityModels;
using NoteWith.Domain.EntitiyModels.UserModels;

namespace NoteWith.Application.Repositorys
{
	public interface ISecurityRepository
	{
		//login register forgetpassword confirmeemail
		/// <summary>
		/// giriş işlemini yapan model
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task<LoginResultModel> Login(LoginDTO model);
		/// <summary>
		/// Kayıt olmaişlemşni yapğaan model
		/// </summary>
		/// <returns></returns>
		Task<LoginResultModel> Register(RegisterDTO model);
		/// <summary>
		/// Emil Dogrulama Kodu metodu
		/// </summary>
		/// <returns></returns>
		Task ConfirmeEmil(EmailConfirmeDTO model);
		/// <summary>
		/// dogrolama emailini göner
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task SendConfirmeEmail(Guid userID);

        Task SendConfirmeEmail(UserModel user);
        /// <summary>
        /// şifres unuttum işlemi için yapılcka kod
        /// </summary>
        /// <param name="model"></param> 
        /// <returns></returns>
        Task ResetPassword(EmailConfirmeDTO model);
		/// <summary>
		/// şifre Sıfırlama emailini gönder
		/// </summary>
		/// <param name="email"></param>
		/// <returns></returns>
		Task SendResetPasswordEmail(string email);
		/// <summary>
		/// Email Başka Kayıt Varmı?
		/// </summary>
		/// <param name="email"></param>
		/// <returns></returns>
		bool IsUnicEmail(string email);
		/// <summary>
		/// JWt ve result bilgileri dönene metod
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		LoginResultModel SetLoginResult(UserModel model);
	}
}

