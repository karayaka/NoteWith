using System;
using NoteWith.Domain.EntitiyModels.BaseModels;

namespace NoteWith.Domain.EntitiyModels.GroupModels
{
	public class WorkGroupAccesKey: BaseEntity
    {
		public WorkGroupAccesKey()
		{
		}
        public Guid WorkGroupID { get; set; }
        public WorkGroup WorkGroup { get; set; }
		/// <summary>
		/// unic key oluşturulup 
		/// </summary>
		public string Key { get; set; }

		public DateTime Expaired { get; set; }
	}
}

