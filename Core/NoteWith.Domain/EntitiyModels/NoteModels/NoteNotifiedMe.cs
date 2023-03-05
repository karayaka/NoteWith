using System;
using NoteWith.Domain.EntitiyModels.BaseModels;
using NoteWith.Domain.EntitiyModels.UserModels;

namespace NoteWith.Domain.EntitiyModels.NoteModels
{
	public class NoteNotifiedMe:BaseEntity
	{
		public NoteNotifiedMe()
		{
		}
        public Guid NoteID { get; set; }
        public Note Note { get; set; }

        public UserModel User { get; set; }
        public Guid UserID { get; set; }
    }
}

