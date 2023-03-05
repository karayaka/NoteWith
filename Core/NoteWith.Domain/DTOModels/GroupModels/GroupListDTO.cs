using System;
using NoteWith.Domain.DTOModels.BaseModel;

namespace NoteWith.Domain.DTOModels.GroupModels
{
	public class GroupListDTO:BaseDTO
	{
		public GroupListDTO()
		{
		}
		public string Name { get; set; }

		public string? Color { get; set; }

        public bool IsManager { get; set; }
	}
}

