using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NoteWith.Domain.DTOModels.CustomExceptionModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NoteWith.Api.Controllers
{
    public class BaseController : Controller
    {
        // GET: /<controller>/
        protected IActionResult ErrorHadler(Exception eror)
        {
            if (eror is UnAuthEx)
                return Unauthorized(eror.Message);
            if (eror is CusEx)
                return BadRequest(eror.Message);
            else
                return BadRequest("Beklenmeyen Bir Hata Oluştu");

        }
    }
}

