using System;
using NoteWith.Domain.EntitiyModels.BaseModels;
using NoteWith.Domain.EntitiyModels.UserModels;

namespace NoteWith.Domain.EntitiyModels.WorkLists
{
	public class WorkListItem:BaseEntity
	{
		public WorkListItem()
		{
		}
		public Guid WorkListID { get; set; }
        public WorkList WorkList { get; set; }

		public string Title { get; set; }

		public string Content { get; set; }

		public bool IsCoplated { get; set; }

		public string? Color { get; set; }

		public Guid? ComplaterUserID { get; set; }
        public UserModel ComplaterUser { get; set; }
		//enetlerden devam edileck gruba eklenen her evet hanerdar edilecek ve bana bildir tabosunda tarih veya değişiklikte haberdar edilecek
    }
}

