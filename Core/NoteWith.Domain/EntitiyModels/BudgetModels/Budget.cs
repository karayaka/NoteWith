using System;
using NoteWith.Domain.EntitiyModels.BaseModels;
using NoteWith.Domain.EntitiyModels.GroupModels;
using NoteWith.Domain.EntitiyModels.UserModels;
using NoteWith.Domain.Enums;

namespace NoteWith.Domain.EntitiyModels.BudgetModels
{
	public class Budget:BaseEntity
	{
		//sadece grup yönetisicisi bütçeyi yönetebilir
		public Budget()
		{
		}
		public BudgeType BudgeType { get; set; }

		public string BudgetName { get; set; }

        public Guid? WorkGroupID { get; set; }
        public WorkGroup WorkGroup { get; set; }//ya grup bütçesi olamalı yada kullanıcı bütçesi olmalı yetkilendirme düşün

		public decimal BudgetTotal { get; set; }

		public Guid? UserID { get; set; }
		public UserModel User { get; set; }

		public ICollection<BudgetDetail> BudgetDetails { get; set; }
	}
}

