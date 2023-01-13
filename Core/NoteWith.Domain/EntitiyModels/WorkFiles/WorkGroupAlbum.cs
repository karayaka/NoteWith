using System;
using NoteWith.Domain.EntitiyModels.BaseModels;
using NoteWith.Domain.EntitiyModels.GroupModels;

namespace NoteWith.Domain.EntitiyModels.WorkFiles
{
	public class WorkGroupAlbum:BaseEntity
	{
		public WorkGroupAlbum()
		{
		}
		public string Name { get; set; }

		public int WorkGroupID { get; set; }
        public WorkGroup WorkGroup { get; set; }

		public ICollection<WorkPhoto> WorkPhotos { get; set; }
	}
}

