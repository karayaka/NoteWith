using System;
namespace NoteWith.Domain.DTOModels.CustomExceptionModels
{
	/// <summary>
	/// Yetkisiz giriş hataları için kullanıalcak exception
	/// </summary>
	public class UnAuthEx:Exception
	{
		public UnAuthEx(string message):base(message)
		{
		}
	}
}

