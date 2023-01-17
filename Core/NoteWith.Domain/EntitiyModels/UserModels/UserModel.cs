using System;
using NoteWith.Domain.EntitiyModels.BaseModels;
using NoteWith.Domain.EntitiyModels.GroupModels;

namespace NoteWith.Domain.EntitiyModels.UserModels
{
	public class UserModel : BaseEntity
	{
		public UserModel()
		{
		}
		public string Name { get; set; }

		public string Surname { get; set; }

		public string Email { get; set; }

		public string Password {get;set;}

		public string? EmailConfirmeToken { get; set; }

		public bool IsEmailConfirmed { get; set; }

		public string? ProfileImage { get; set; }

		public string? FireBaseConnectionID { get; set; }

        public ICollection<WorkGroupUsers> WorkGroupUsers { get; set; }
    }
}

