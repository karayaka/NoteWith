using System;
using NoteWith.Domain.EntitiyModels.BaseModels;
using NoteWith.Domain.EntitiyModels.GroupModels;

namespace NoteWith.Domain.EntitiyModels.NoticeModels
{
	public class WorkGroupNotice:BaseEntity
	{
		public WorkGroupNotice()
		{
		}

		public int NoticeID { get; set; }
        public Notice Notice { get; set; }

		public int WorkGroupID { get; set; }
        public WorkGroup WorkGroup { get; set; }
    }
}

