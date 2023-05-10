using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteWith.Application.Repositorys;

namespace NoteWith.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        public BudgetController(IUnitOfWork _uow)
        {
            uow= _uow;
        }

    }
}
