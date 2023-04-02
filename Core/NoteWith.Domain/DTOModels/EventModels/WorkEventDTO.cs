using System;
using NoteWith.Domain.DTOModels.BaseModel;

namespace NoteWith.Domain.DTOModels.EventModels
{
	public class WorkEventDTO:BaseDTO
	{
		public WorkEventDTO()
		{
		}

        public string Title { get; set; }
        public string? Content { get; set; }

		public string NotificationID { get; set; }

        public bool IsComplated { get; set; }

        public DateTime Date { get; set; }

		public List<Guid> SharedGroups { get; set; }
	}
}

