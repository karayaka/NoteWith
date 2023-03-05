using System;
using NoteWith.Domain.DTOModels.GroupModels;

namespace NoteWith.Domain.DTOModels.NoteModels
{
	public class NoteListDTO
	{
		public NoteListDTO()
		{
		}
        public Guid ID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string? Color { get; set; }

        public bool IsOwner { get; set; }

        public bool CanEdit { get; set; }

        public bool NotifiedMe { get; set; }

        public List<GroupListDTO> NoteGroups { get; set; }
    }
}

