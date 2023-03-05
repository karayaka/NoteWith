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

		public Guid EventID { get; set; }
        public WorkEvent Event { get; set; }

        public Guid WorkGroupID { get; set; }
        public WorkGroup WorkGroup { get; set; }
    }
}

