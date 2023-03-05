using System;
using NoteWith.Domain.DTOModels.BaseModel;
using NoteWith.Domain.EntitiyModels.GroupModels;

namespace NoteWith.Domain.DTOModels.SecurityModels
{
	public class SessionModel:BaseDTO
	{
		public SessionModel()
		{
		}
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public bool IsConfirmeEmail { get; set; }

        public string? ProfileImage { get; set; }

        public string? FireBaseConnectionID { get; set; }

    }
}

