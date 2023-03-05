using System;
using NoteWith.Domain.DTOModels.BaseModel;

namespace NoteWith.Domain.DTOModels.WorklistModels
{
	public class CreateWorkListDTO:BaseDTO
	{
		public CreateWorkListDTO()
		{
		}

        public string Title { get; set; }

        public string Desc { get; set; }

        public string Color { get; set; }

        public List<Guid> SharedGroups { get; set; }

        public List<WorkListItemDTO> Items { get; set; }

    }
}

