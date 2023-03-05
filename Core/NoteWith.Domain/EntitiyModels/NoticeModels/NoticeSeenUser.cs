using System;
using NoteWith.Domain.EntitiyModels.BaseModels;
using NoteWith.Domain.EntitiyModels.UserModels;

namespace NoteWith.Domain.EntitiyModels.NoticeModels
{
	public class NoticeSeenUser:BaseEntity
	{
		public NoticeSeenUser()
		{
		}
		public Guid NoticeID { get; set; }
        public Notice Notice { get; set; }

		public Guid UserID { get; set; }
        public UserModel User { get; set; }
    }
}

