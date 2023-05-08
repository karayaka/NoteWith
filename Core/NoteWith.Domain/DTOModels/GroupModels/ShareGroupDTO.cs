using NoteWith.Domain.DTOModels.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteWith.Domain.DTOModels.GroupModels
{
    public class ShareGroupDTO:BaseDTO
    {
        public Guid ObjectId { get; set; }

        public List<Guid> GroupIds { get; set; }
    }
}
