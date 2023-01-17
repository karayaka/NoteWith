using System;
namespace NoteWith.Domain.DTOModels.CustomExceptionModels
{
	/// <summary>
	/// Elle Gönderilecek tüm hatalar için kullanılacak
	/// </summary>
	public class CusEx:Exception
	{
		public CusEx():base("Beklenmeyen Bir Hata Oluştu")
		{

		}
		public CusEx(string message):base(message)
		{
		}
	}
}

