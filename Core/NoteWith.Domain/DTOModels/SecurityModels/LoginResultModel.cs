using System;
using NoteWith.Domain.DTOModels.BaseModel;

namespace NoteWith.Domain.DTOModels.SecurityModels
{
	public class LoginResultModel:BaseDTO
	{
		public LoginResultModel()
		{
		}
		public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string ProfilImage { get; set; }
		public string Token { get; set; }
	}
}

