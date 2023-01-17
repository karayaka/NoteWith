using System;
using System.ComponentModel.DataAnnotations;
using NoteWith.Domain.DTOModels.BaseModel;

namespace NoteWith.Domain.DTOModels.SecurityModels
{
	public class LoginDTO:BaseDTO
	{
		public LoginDTO()
		{
		}
        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

		public string Password { get; set; }

        public string? FireBaseConnectionID { get; set; }

    }
}

