using System;
using NoteWith.Domain.EntitiyModels.BaseModels;
using NoteWith.Domain.EntitiyModels.UserModels;

namespace NoteWith.Domain.EntitiyModels.MessageModels
{
	public class PersonelMessageModel:BaseEntity
	{
		public PersonelMessageModel()
		{
		}
		public int SenderID { get; set; }
        public UserModel Sender { get; set; }

		public int ReceiverID { get; set; }
        public UserModel Receiver { get; set; }

		public string Message { get; set; }

		public DateTime Date { get; set; }
	}
}

