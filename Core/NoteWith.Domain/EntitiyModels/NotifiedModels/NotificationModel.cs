using System;
using NoteWith.Domain.EntitiyModels.BaseModels;
using NoteWith.Domain.EntitiyModels.UserModels;

namespace NoteWith.Domain.EntitiyModels.NotifiedModels
{
	public class NotificationModel:BaseEntity
	{
		public NotificationModel()
		{
		}
		public Guid UserID { get; set; }
		public UserModel User { get; set; }

		public string Title { get; set; }

		public string Body { get; set; }

		public bool IsSeen { get; set; }
	}
}

