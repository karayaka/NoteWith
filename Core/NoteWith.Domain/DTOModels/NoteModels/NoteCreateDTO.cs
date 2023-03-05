using System;
namespace NoteWith.Domain.DTOModels.NoteModels
{
	public class NoteCreateDTO
	{
		public NoteCreateDTO()
		{
		}
        public Guid ID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string? Color { get; set; }

        public List<Guid> SharedGoups { get; set; }
    }
}

