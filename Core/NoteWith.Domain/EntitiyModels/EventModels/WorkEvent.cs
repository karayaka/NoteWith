using System;
using NoteWith.Domain.EntitiyModels.BaseModels;

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

		public bool IsComplated { get; set; }

		public ICollection<WorkEventGroup> Groups { get; set; }

        public ICollection<WorkEventNotifiedMe> NotifiedMes { get; set; }

        public ICollection<WorkEventExcludedUser> ExcludedUsers { get; set; }

    }
}

