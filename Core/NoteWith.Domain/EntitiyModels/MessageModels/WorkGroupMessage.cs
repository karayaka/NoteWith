using System;
using NoteWith.Domain.EntitiyModels.BaseModels;
using NoteWith.Domain.EntitiyModels.GroupModels;
using NoteWith.Domain.EntitiyModels.UserModels;

namespace NoteWith.Domain.EntitiyModels.MessageModels
{
	public class WorkGroupMessage:BaseEntity
	{
		public WorkGroupMessage()
		{
		}
		public Guid WorkGroupID { get; set; }
        public WorkGroup WorkGroup { get; set; }

		public Guid SenderID { get; set; }
        public UserModel Sender { get; set; }

		public string Message { get; set; }

		public string Date { get; set; }
	}
}

