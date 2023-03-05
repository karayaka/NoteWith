using System;
using NoteWith.Domain.DTOModels.BaseModel;

namespace NoteWith.Domain.DTOModels.NotifiedModels
{
	public class NotificationDTO:BaseDTO
	{
		public NotificationDTO()
		{
		}
        public Guid UserID { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }
    }
}

