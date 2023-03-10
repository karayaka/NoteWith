using System;
using NoteWith.Domain.EntitiyModels.BaseModels;
using NoteWith.Domain.EntitiyModels.Labels;

namespace NoteWith.Domain.EntitiyModels.EventModels
{
	public class WorkEvent:BaseEntity
	{
		public WorkEvent()
		{
		}

		public string Title { get; set; }
		public string? Content { get; set; }

		public DateTime Date { get; set; }

		public ICollection<WorkEventGroup> Groups { get; set; }

        public ICollection<WorkEventNotifiedMe> NotifiedMes { get; set; }

        public ICollection<WorkEventExcludedUser> ExcludedUsers { get; set; }

        public ICollection<WorkLabel> Labels { get; set; }

    }
}

