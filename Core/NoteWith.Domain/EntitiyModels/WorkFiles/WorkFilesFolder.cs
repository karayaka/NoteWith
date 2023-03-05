using System;
using NoteWith.Domain.EntitiyModels.BaseModels;
using NoteWith.Domain.EntitiyModels.GroupModels;
using NoteWith.Domain.Enums;

namespace NoteWith.Domain.EntitiyModels.WorkFiles
{
	public class WorkFilesFolder:BaseEntity
	{
		public WorkFilesFolder()
		{
		}
		public string Title { get; set; }

		public Guid WorkGroupID { get; set; }

        public WorkGroup WorkGroup { get; set; }

		public ICollection<WorkFile> WorkFiles { get; set; }
	}
}

