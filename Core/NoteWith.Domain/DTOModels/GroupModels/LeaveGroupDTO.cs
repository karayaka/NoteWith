using NoteWith.Domain.DTOModels.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteWith.Domain.DTOModels.GroupModels
{
    public class LeaveGroupDTO:BaseDTO
    {
        public Guid ObjectId { get; set; }
        public Guid GroupId { get; set; }
    }
}
