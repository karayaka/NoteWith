using System;
using NoteWith.Domain.EntitiyModels.BaseModels;
using NoteWith.Domain.EntitiyModels.UserModels;

namespace NoteWith.Domain.EntitiyModels.WorkLists
{
	public class WorkListExcludedUser:BaseEntity
	{
		public WorkListExcludedUser()
		{
		}
		public int WorkListID { get; set; }
        public WorkList WorkList { get; set; }

        public int UserID { get; set; }
        public UserModel User { get; set; }

        public string? Desc { get; set; }
    }
}

