using NoteWith.Domain.DTOModels.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteWith.Domain.EntitiyModels.BudgetModels
{
    public class BudgeDetailListDTO:BaseDTO
    {
        public Guid BudgetID { get; set; }

        public string Desc { get; set; }

        public decimal Sum { get; set; }//hepa hareketindeki parasal tutatr
    }
}
