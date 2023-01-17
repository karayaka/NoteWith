using System;
using NoteWith.Domain.EntitiyModels.GroupModels;

namespace NoteWith.Domain.DTOModels.SecurityModels
{
	public class RegisterDTO
	{
		public RegisterDTO()
		{
		}
        public string Name { get; set; }

        public string Surname { get; set; }

        public bool IsGoogleLogin { get; set; }

        public string Email { get; set; }

        public string? ProfileImage { get; set; }

        public string? FireBaseConnectionID { get; set; }

    }
}

