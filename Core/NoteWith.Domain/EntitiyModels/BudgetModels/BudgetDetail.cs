using System;
using NoteWith.Domain.EntitiyModels.BaseModels;
using NoteWith.Domain.EntitiyModels.UserModels;
using NoteWith.Domain.Enums;

namespace NoteWith.Domain.EntitiyModels.BudgetModels
{
	public class BudgetDetail:BaseEntity
	{
		public BudgetDetail()
		{
		}
		public Guid BudgetID { get; set; }
        public Budget Budget { get; set; }

        public string Desc { get; set; }

		public BudgetDetailType BudgetDetailType { get; set; }

		public Guid? UserID { get; set; }
        public UserModel User { get; set; }
    }
}

