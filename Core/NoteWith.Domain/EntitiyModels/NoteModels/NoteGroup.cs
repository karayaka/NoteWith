using System;
using NoteWith.Domain.EntitiyModels.BaseModels;
using NoteWith.Domain.EntitiyModels.GroupModels;

namespace NoteWith.Domain.EntitiyModels.NoteModels
{
	public class NoteGroup:BaseEntity
	{
		public NoteGroup()
		{
		}

		public Guid NoteID { get; set; }
        public Note Note { get; set; }

		public Guid WorkGroupID { get; set; }
        public WorkGroup WorkGroup { get; set; }
    }
}

