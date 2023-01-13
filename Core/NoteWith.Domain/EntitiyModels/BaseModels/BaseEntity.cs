using System;
using NoteWith.Domain.Enums;

namespace NoteWith.Domain.EntitiyModels.BaseModels
{
	public class BaseEntity
	{
		public BaseEntity()
		{
			CreadedBy = Guid.Empty;
			UpdatedBy = Guid.Empty;
			CreadedDate = DateTime.Now;
			UpdatedDate = DateTime.Now;
		}

		public Guid ID { get; set; }


		public Guid? CreadedBy { get; set; }


        public Guid? UpdatedBy { get; set; }


		public DateTime CreadedDate { get; set; }


		public DateTime UpdatedDate { get; set; }


		public ObjectStatus ObjectStatus { get; set; }


		public Status Status { get; set; }
	}
}

