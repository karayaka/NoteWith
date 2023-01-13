using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace NoteWith.Domain.Enums
{
	public enum FileTyps
	{
        [Display(Name = "Resim")]
        Image = 0,
        [Display(Name = "Dosya")]
        File = 1
    }
}

