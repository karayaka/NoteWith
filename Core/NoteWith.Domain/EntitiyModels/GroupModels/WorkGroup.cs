using System;
using NoteWith.Domain.EntitiyModels.BaseModels;
using NoteWith.Domain.EntitiyModels.EventModels;
using NoteWith.Domain.EntitiyModels.MessageModels;
using NoteWith.Domain.EntitiyModels.NoteModels;
using NoteWith.Domain.EntitiyModels.NoticeModels;
using NoteWith.Domain.EntitiyModels.WorkFiles;
using NoteWith.Domain.EntitiyModels.WorkLists;

namespace NoteWith.Domain.EntitiyModels.GroupModels
{
	public class WorkGroup:BaseEntity
	{
		public WorkGroup()
		{
		}
		public string Name { get; set; }

		public string? Color { get; set; }

		public string GroupFirebaseConnctionID { get; set; }

		public ICollection<WorkGroupUsers> WorkGroupUsers { get; set; }

		public ICollection<WorkEventGroup> EventGroups { get; set; }

		public ICollection<WorkGroupMessage> Messages { get; set; }

        public ICollection<NoteGroup> NoteGroups { get; set; }

		public ICollection<WorkGroupNotice> Notices { get; set; }
		//bir grup oluşur oluşmaz bir adt dosya ekle
		public ICollection<WorkFilesFolder> Folders { get; set; }

		public ICollection<WorkGroupAlbum> Albums { get; set; }

		public ICollection<ListWorkGroup> WorkLists { get; set; }
	}
}

