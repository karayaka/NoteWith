using System;
using NoteWith.Domain.EntitiyModels.BaseModels;

namespace NoteWith.Domain.EntitiyModels.NoteModels
{
	public class Note:BaseEntity
	{
		public Note()
		{
		}
		public string Title { get; set; }

		public string Content { get; set; }

		public string? Color { get; set; }
		/// <summary>
		/// Paylaşan gruplar notu güncelleyebilcekmi Günceleyemeyecek mi paylaşım ekranında sorulacak!
		/// </summary>
		public bool GroupEditable { get; set; } = false;

		public ICollection<NoteExcludedUser> ExcludedUsers { get; set; }

		public ICollection<NoteGroup> NoteGroups { get; set; }

		public ICollection<NoteNotifiedMe> Notifieds { get; set; }//not değiştiğinde haberdar edilecek kullanılaak
    }
}

