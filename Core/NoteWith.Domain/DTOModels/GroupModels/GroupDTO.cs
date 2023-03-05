using System;
using NoteWith.Domain.DTOModels.BaseModel;

namespace NoteWith.Domain.DTOModels.GroupModels
{
	public class GroupDTO:BaseDTO
	{
		public GroupDTO()
		{
		}

        public string Name { get; set; }

        public string? Color { get; set; }
    }
}

