using System;
using NoteWith.Domain.EntitiyModels.BaseModels;

namespace NoteWith.Domain.EntitiyModels.WorkFiles
{
	public class WorkPhoto:BaseEntity
	{
		public WorkPhoto()
		{
		}
		public Guid AlbumID { get; set; }
        public WorkGroupAlbum Album { get; set; }

		public string Name { get; set; }

		public string UrlSmallImage { get; set; }

		public string UrlMediumImage { get; set; }

		public string UrlOrgin { get; set; }
	}
}

