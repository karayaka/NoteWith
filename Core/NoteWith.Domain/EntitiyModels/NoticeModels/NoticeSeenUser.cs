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
		public int NoticeID { get; set; }
        public Notice Notice { get; set; }

		public int UserID { get; set; }
        public UserModel User { get; set; }
    }
}

