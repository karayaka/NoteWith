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
		public int NoteID { get; set; }
        public Note Note { get; set; }

        public int UserID { get; set; }
        public UserModel User { get; set; }

        public string? Desc { get; set; }
    }
}

