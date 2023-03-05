using System;
using NoteWith.Domain.EntitiyModels.BaseModels;
using NoteWith.Domain.EntitiyModels.UserModels;

namespace NoteWith.Domain.EntitiyModels.NoteModels
{
	public class NoteExcludedUser:BaseEntity
	{
		public NoteExcludedUser()
		{
		}
		public Guid NoteID { get; set; }
        public Note Note { get; set; }

        public Guid UserID { get; set; }
        public UserModel User { get; set; }

        public string? Desc { get; set; }
    }
}

