using System;
using NoteWith.Domain.EntitiyModels.BaseModels;
using NoteWith.Domain.EntitiyModels.GroupModels;

namespace NoteWith.Domain.EntitiyModels.NoticeModels
{
	public class Notice:BaseEntity
	{
		public Notice()
		{
		}
		//notice(Duyuru) eklenir eklenemez gruplara bildirim gidicek
        public string Content { get; set; }

		public DateTime EndDate { get; set; }

		public ICollection<NoticeSeenUser> SeenUsers { get; set; }

		public ICollection<WorkGroupNotice> WorkGroups { get; set; }
	}
}

