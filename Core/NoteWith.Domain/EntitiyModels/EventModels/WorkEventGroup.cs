using System;
using NoteWith.Domain.EntitiyModels.BaseModels;
using NoteWith.Domain.EntitiyModels.GroupModels;

namespace NoteWith.Domain.EntitiyModels.EventModels
{
	public class WorkEventGroup:BaseEntity
	{
		public WorkEventGroup()
		{
		}

		public int EventID { get; set; }
        public WorkEvent Event { get; set; }

        public int WorkGroupID { get; set; }
        public WorkGroup WorkGroup { get; set; }
    }
}

