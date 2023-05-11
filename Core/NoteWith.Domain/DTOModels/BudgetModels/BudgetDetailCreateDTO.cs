using NoteWith.Domain.DTOModels.BaseModel;
using NoteWith.Domain.EntitiyModels.BudgetModels;
using NoteWith.Domain.EntitiyModels.UserModels;
using NoteWith.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteWith.Domain.DTOModels.BudgetModels
{
    public class BudgetDetailCreateDTO:BaseDTO
    {
        public Guid BudgetID { get; set; }

        public string Desc { get; set; }

        public decimal Sum { get; set; }

        public BudgetDetailType BudgetDetailType { get; set; }

        public Guid? UserID { get; set; }
    }
}
