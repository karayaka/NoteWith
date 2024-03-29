﻿using System;
using NoteWith.Domain.EntitiyModels.BaseModels;
using NoteWith.Domain.EntitiyModels.UserModels;

namespace NoteWith.Domain.EntitiyModels.GroupModels
{
	public class WorkGroupUsers:BaseEntity
	{
		public WorkGroupUsers()
		{
		}
		public WorkGroup WorkGroup { get; set; }
        public Guid WorkGroupID { get; set; }

        public UserModel User { get; set; }
        public Guid UserID { get; set; }

		public bool IsManager { get; set; }//her grup için bir yönetici olablir

		public bool IsNute { get; set; }
	}
}

