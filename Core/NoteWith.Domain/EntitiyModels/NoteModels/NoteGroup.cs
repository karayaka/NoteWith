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

		public int NoteID { get; set; }
        public Note Note { get; set; }

		public int WorkGroupID { get; set; }
        public WorkGroup WorkGroup { get; set; }
    }
}

