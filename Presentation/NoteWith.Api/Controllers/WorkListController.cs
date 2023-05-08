using Microsoft.AspNetCore.Mvc;
using NoteWith.Application.Repositorys;
using NoteWith.Domain.DTOModels.BaseModel;
using NoteWith.Domain.DTOModels.GroupModels;
using NoteWith.Domain.DTOModels.WorklistModels;

namespace NoteWith.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkListController : ControllerBase
    {
        public readonly IUnitOfWork uow;
        public WorkListController(IUnitOfWork _uow)
        {
            uow= _uow;
        }
        [HttpGet("GetAllWorkList")]
        public async Task<IActionResult> GetAllWorkList([FromQuery]string q,int page,List<Guid> groupIds)
        {
            var lists=await uow.WorkListRepository.GetWorkLists(q, groupIds);
            var pageCount = uow.Repository.GetPageCount(lists, 25);
            var listPaginationed = uow.Repository.GetPaginate(lists, page, 25);

            return Ok(new ResultDTO<IQueryable<WorkListDTO>>(
                _Data: uow.WorkListRepository.ConvertWorkListGroups(listPaginationed),
                _PageSize: 25,
                _PageCount: pageCount));
        }

        [HttpGet("GetGroupList")]
        public async Task<IActionResult> GetGroupList([FromQuery] string q, int page, List<Guid> groupIds)
        {
            var lists = await uow.WorkListRepository.GetGroupsWorkLists(q, groupIds);
            var pageCount = uow.Repository.GetPageCount(lists, 25);
            var listPaginationed = uow.Repository.GetPaginate(lists, page, 25);

            return Ok(new ResultDTO<IQueryable<WorkListDTO>>(
                _Data: uow.WorkListRepository.ConvertWorkListGroups(listPaginationed),
                _PageSize: 25,
                _PageCount: pageCount));
        }
        [HttpGet("GetUserList")]
        public IActionResult GetUserList([FromQuery]string q, int page)
        {
            var lists = uow.WorkListRepository.GetUserWorkLists(q);
            var pageCount = uow.Repository.GetPageCount(lists, 25);
            var listPaginationed = uow.Repository.GetPaginate(lists, page, 25);

            return Ok(new ResultDTO<IQueryable<WorkListDTO>>(
                _Data: uow.WorkListRepository.ConvertWorkListGroups(listPaginationed),
                _PageSize: 25,
                _PageCount: pageCount));
        }
        [HttpPost("AddWorkList")]
        public async Task<IActionResult> AddWorkList(CreateWorkListDTO model)
        {
            await uow.WorkListRepository.AddWorkList(model);
            return Ok();
        }

        [HttpDelete("DeleteWorkList/{Id}")]
        public async Task<IActionResult> DeleteWorkList(Guid Id)
        {
            await uow.WorkListRepository.DeleteWorkList(Id);
            return Ok();
        }
        [HttpPut("UpdateWorkList")]
        public async Task<IActionResult> UpdateWorkList(CreateWorkListDTO model)
        {
            await uow.WorkListRepository.UpdateWorkList(model);
            return Ok();
        }
        [HttpPost("ShareGroup")]
        public async Task<IActionResult> ShareGroup(ShareGroupDTO model)
        {
            await uow.WorkListRepository.ShareGroup(model.ObjectId, model.GroupIds);
            return Ok();
        }
        [HttpPost("TogleNotifiedMe/{Id}")]
        public async Task<IActionResult> TogleNotifiedMe(Guid Id)
        {
            await uow.WorkListRepository.TogleNotifiedMe(Id);
            return Ok();
        }
        [HttpPost("AddListItem/{Id}")]
        public async Task<IActionResult> AddListItem(WorkListItemDTO workListItem)
        {
            await uow.WorkListRepository.AddItemsToList(workListItem);
            return Ok();
        }
        [HttpPut("UpdateListItem")]
        public async Task<IActionResult> UpdateListItem(WorkListItemDTO workListItem)
        {
            await uow.WorkListRepository.UpdateWorkListItem(workListItem);
            return Ok();
        }
        [HttpDelete("DeleteListItem/{Id}")]
        public async Task<IActionResult> DeleteListItem(Guid Id)
        {
            await uow.WorkListRepository.DeleteWorkListItem(Id);
            return Ok();
        }
        [HttpPost("TogleItemComplated/{Id}")]
        public async Task<IActionResult> TogleItemComplated(Guid Id)
        {
            await uow.WorkListRepository.TogleItemComplated(Id);
            return Ok();
        }
    }
}
