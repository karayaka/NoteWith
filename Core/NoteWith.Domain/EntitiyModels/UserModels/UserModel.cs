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

		public string? ProfileImage { get; set; }//http ile bişlarsa google dosya ismi yazılıysa profil güncelleme

		public string? FireBaseConnectionID { get; set; }//bu ıd nerden gelcek akılacak

        public ICollection<WorkGroupUsers> WorkGroupUsers { get; set; }
		public ICollection<WorkGroupAccesKey> WorkGroupAccesKeys { get; set; }
    }
}

