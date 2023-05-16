using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteWith.Application.Repositorys;
using NoteWith.Domain.DTOModels.BaseModel;
using NoteWith.Domain.DTOModels.BudgetModels;
using NoteWith.Domain.DTOModels.NoteModels;
using NoteWith.Domain.EntitiyModels.NoteModels;

namespace NoteWith.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BudgetController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        public BudgetController(IUnitOfWork _uow)
        {
            uow= _uow;
        }

        [HttpGet("GetAllBudget")]
        public async Task<IActionResult> GetAllBudget()=> Ok(new ResultDTO<IQueryable<BudgetListDTO>>
                (_Data: await uow.BudgetRepository.GetAllBudget()));

        [HttpGet("GetUserBudget")]
        public IActionResult GetUserBudeget() =>
            Ok(new ResultDTO<IQueryable<BudgetListDTO>>(_Data: uow.BudgetRepository.GetUserBudget()));

        [HttpGet("GetBudegtDetail")]
        public async Task<IActionResult>GetBudegtDetail([FromQuery]Guid Id,string q,int page)
        {
            var budgetDetail = uow.BudgetRepository.GetBudgetDetail(Id, q);
            var pageCount = uow.Repository.GetPageCount(budgetDetail, 25);
            var butgetPaging = uow.Repository.GetPaginate(budgetDetail, page, 25);
            return Ok(new ResultDTO<IQueryable<BudgetDetailListDTO>>(
                _Data: uow.BudgetRepository.ConvertBudgetDetail(butgetPaging),
                _PageSize: 25,
                _PageCount: pageCount));
        }

        [HttpPost("AddBudegt")]
        public async Task<IActionResult>AddBudegt(BudetCreateDTO model)
        {
            await uow.BudgetRepository.AddBudget(model);
            await uow.SaveChange();
            return Ok();
        }

        [HttpPut("UpdateBudget")]
        public async Task<IActionResult>UpdateBudget(BudetCreateDTO model)
        {
            await uow.BudgetRepository.UpdateBudget(model);
            await uow.SaveChange();
            return Ok();
        }

        [HttpDelete("DeleteBudget/{Id}")]
        public async Task<IActionResult>DeleteBudget(Guid Id)
        {
            await uow.BudgetRepository.DeleteBudget(Id);
            await uow.SaveChange();
            return Ok();
        }
        [HttpPost("AddBudegtDetail")]
        public async Task<IActionResult>AddBudegtDetail(BudgetDetailCreateDTO model)
        {
            await uow.BudgetRepository.AddBudgetDetail(model);
            await uow.SaveChange();
            return Ok();
        }
        [HttpPut("UpdateBudgetDetail")]
        public async Task<IActionResult> UpdateBudgetDetail(BudgetDetailCreateDTO model)
        {
            await uow.BudgetRepository.UpdateBudgetDetail(model);
            await uow.SaveChange();
            return Ok();
        }
        [HttpDelete("DeleteBudegtDetail/{Id}")]
        public async Task<IActionResult> DeleteBudegtDetail(Guid Id)
        {
            await uow.BudgetRepository.DeleteBudgetDetail(Id);
            await uow.SaveChange();
            return Ok();
        }
    }
}
