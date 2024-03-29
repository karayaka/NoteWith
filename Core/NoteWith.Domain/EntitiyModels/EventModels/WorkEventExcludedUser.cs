﻿using System;
using NoteWith.Domain.EntitiyModels.BaseModels;
using NoteWith.Domain.EntitiyModels.NoteModels;
using NoteWith.Domain.EntitiyModels.UserModels;

namespace NoteWith.Domain.EntitiyModels.EventModels
{
	public class WorkEventExcludedUser:BaseEntity
	{
		public WorkEventExcludedUser()
		{
		}

        public Guid EventID { get; set; }
        public WorkEvent Event { get; set; }

        public Guid UserID { get; set; }
        public UserModel User { get; set; }

        public string? Desc { get; set; }
    }
}

