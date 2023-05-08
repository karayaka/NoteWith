using System;
using NoteWith.Domain.DTOModels.SecurityModels;
using NoteWith.Domain.EntitiyModels.UserModels;

namespace NoteWith.Application.Services
{
	public interface ITokenGeneratorService
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="user"></param>
		/// <param name="expiredDate"></param>
		/// <returns></returns>
		string JWTTokenGenerate(SessionModel user, DateTime expiredDate);
		/// <summary>
		/// Emil doğrulama vb işlemler için token geberator
		/// </summary>
		/// <param name="DigitCount"></param>
		/// <returns></returns>
		string DigitTokenGenerator(int DigitCount = 6);
		/// <summary>
		/// çalışma grubuna kişi eklemek için kullanılacak key
		/// </summary>
		/// <returns></returns>
		string GenerateWorkgroupAccessKey();
	}	
}

