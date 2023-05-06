using NoteWith.Domain.DTOModels.BaseModel;
using NoteWith.Domain.EntitiyModels.BudgetModels;
using NoteWith.Domain.EntitiyModels.GroupModels;
using NoteWith.Domain.EntitiyModels.UserModels;
using NoteWith.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteWith.Domain.DTOModels.BudgetModels
{
    public class BudetCreateDTO:BaseDTO
    {
        public BudgeType BudgeType { get; set; }

        public string BudgetName { get; set; }

        public Guid? WorkGroupID { get; set; }
        
        public Guid? UserID { get; set; }
    }
}
