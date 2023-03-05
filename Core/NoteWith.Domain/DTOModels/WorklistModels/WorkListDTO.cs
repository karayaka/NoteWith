using System;
using NoteWith.Domain.DTOModels.BaseModel;

namespace NoteWith.Domain.DTOModels.WorklistModels
{
	public class WorkListDTO:BaseDTO
	{
		public WorkListDTO()
		{
		}

        public string Title { get; set; }

        public string Desc { get; set; }

        public string Color { get; set; }

		public bool IsListComlated { get; set; }

		public bool CanEdit { get; set; }//bu kullanıcı editleye bilirmni

		public List<WorkListItemDTO> Items { get; set; }
	}
}

