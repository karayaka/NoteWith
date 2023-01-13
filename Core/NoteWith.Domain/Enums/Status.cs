using System;
using System.ComponentModel.DataAnnotations;

namespace NoteWith.Domain.Enums
{
	public enum Status
	{
        [Display(Name = "Aktif")]
        Active = 1,

        [Display(Name = "Pasif")]
        Pasive = 0,
	}
}

