using System;
using NoteWith.Domain.DTOModels.BaseModel;

namespace NoteWith.Domain.DTOModels.NoticeModels
{
	public class NoticeDTO: BaseDTO
    {
		public NoticeDTO()
		{
		}
        public List<Guid> WorkGroups { get; set; }

        public string Content { get; set; }

        public DateTime EndDate { get; set; }
    }
}

