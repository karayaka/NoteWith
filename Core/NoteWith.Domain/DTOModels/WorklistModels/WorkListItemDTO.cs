using System;
using NoteWith.Domain.DTOModels.BaseModel;

namespace NoteWith.Domain.DTOModels.WorklistModels
{
	public class WorkListItemDTO:BaseDTO
	{
		public WorkListItemDTO()
		{
		}
        public Guid WorkListID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public bool IsCoplated { get; set; }

        public string? Color { get; set; }

        public string ComplatedUser { get; set; }

        public List<Guid> SharedGoups { get; set; }
    }
}

