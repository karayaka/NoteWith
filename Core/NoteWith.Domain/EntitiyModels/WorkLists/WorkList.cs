using System;
using NoteWith.Domain.EntitiyModels.BaseModels;

namespace NoteWith.Domain.EntitiyModels.WorkLists
{
	public class WorkList:BaseEntity
	{
		public WorkList()
		{
		}
		public string Title { get; set; }

		public string? Desc { get; set; }

		public string? Color { get; set; }

		public ICollection<WorkListItem> Items { get; set; }

        public ICollection<WorkListExcludedUser> ExcludedUsers { get; set; }

        public ICollection<ListWorkGroup> WorkGroups { get; set; }

        public ICollection<WorkListNotifiedMe> WorkListNotifiedMes { get; set; }

    }
}

