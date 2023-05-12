using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteWith.Application.Repositorys;

namespace NoteWith.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalenderController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        public CalenderController(IUnitOfWork _uow)
        {
            uow= _uow;
        }
        //table nin durumuna göre doldurulacak
    }
}
