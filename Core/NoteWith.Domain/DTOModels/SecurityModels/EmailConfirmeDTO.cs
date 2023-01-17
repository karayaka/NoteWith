using System;
using NoteWith.Domain.DTOModels.BaseModel;

namespace NoteWith.Domain.DTOModels.SecurityModels
{
	public class EmailConfirmeDTO:BaseDTO
	{
		public EmailConfirmeDTO()
		{
		}

		public string Email { get; set; }

		public string Token { get; set; }

		public string NewPassword { get; set; }
	}
}

