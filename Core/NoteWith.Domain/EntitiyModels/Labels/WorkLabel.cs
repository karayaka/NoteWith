using System;
using NoteWith.Domain.EntitiyModels.BaseModels;
using NoteWith.Domain.EntitiyModels.EventModels;
using NoteWith.Domain.EntitiyModels.NoteModels;
using NoteWith.Domain.EntitiyModels.WorkLists;

namespace NoteWith.Domain.EntitiyModels.Labels
{
	public class WorkLabel:BaseEntity
	{
		public WorkLabel()
		{
		}
		public string Name { get; set; }

		public ICollection<Note> Notes { get; set; }

		public ICollection<WorkEvent> WorkEvents { get; set; }

		public ICollection<WorkList> WorkLists { get; set; }
	}
}

