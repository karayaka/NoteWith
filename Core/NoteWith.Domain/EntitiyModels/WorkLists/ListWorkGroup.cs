using System;
using NoteWith.Domain.EntitiyModels.BaseModels;
using NoteWith.Domain.EntitiyModels.GroupModels;

namespace NoteWith.Domain.EntitiyModels.WorkLists
{
	public class ListWorkGroup:BaseEntity
	{
		public ListWorkGroup()
		{
		}
		public int WorkListID { get; set; }
        public WorkList WorkList { get; set; }

		public int WorkGroupID { get; set; }
        public WorkGroup WorkGroup { get; set; }
    }
}

