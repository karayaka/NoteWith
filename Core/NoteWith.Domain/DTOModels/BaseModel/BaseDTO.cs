using System;
namespace NoteWith.Domain.DTOModels.BaseModel
{
	public class BaseDTO
	{
		public BaseDTO()
		{
			ID = Guid.Empty;
		}
		public Guid ID { get; set; }
	}
}

