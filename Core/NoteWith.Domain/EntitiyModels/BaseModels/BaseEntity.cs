using System;
namespace NoteWith.Domain.EntitiyModels.BaseModels
{
	public class BaseEntity
	{
		public BaseEntity()
		{
		}
		public Guid ID { get; set; }

		public Guid? Crea { get; set; }
	}
}

