using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NoteWith.Application.Repositorys;
using NoteWith.Domain.DTOModels.BaseModel;
using NoteWith.Domain.DTOModels.EventModels;
using NoteWith.Domain.DTOModels.GroupModels;
using NoteWith.Domain.DTOModels.NoteModels;
using System.Text.RegularExpressions;

namespace NoteWith.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkEvetController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        public WorkEvetController(IUnitOfWork _uow)
        {
            uow= _uow;
        }

        [HttpGet("GetAllWorkEvent")]
        public async Task<IActionResult> GetAllWorkEvent([FromQuery] int page, string q, List<Guid> groupId)
        {
            var workEvent = await uow.WorkEventRepository.GetWorkEvents(q, groupId);
            var pageCount = uow.Repository.GetPageCount(workEvent, 25);
            var notesPaging = uow.Repository.GetPaginate(workEvent, page, 25);
            return Ok(new ResultDTO<IQueryable<WorkEventDTO>>(
                _Data: uow.WorkEventRepository.ConvertWorkEvntModel(notesPaging),
                _PageSize: 25,
                _PageCount: pageCount));
        }
        [HttpGet("GetGroupEvents")]
        public async Task<IActionResult> GetGroupEvents([FromQuery] int page, string q, List<Guid> groupId)
        {
            var workEvent = await uow.WorkEventRepository.GetGroupWorkEvents(q, groupId);
            var pageCount = uow.Repository.GetPageCount(workEvent, 25);
            var notesPaging = uow.Repository.GetPaginate(workEvent, page, 25);
            return Ok(new ResultDTO<IQueryable<WorkEventDTO>>(
                _Data: uow.WorkEventRepository.ConvertWorkEvntModel(notesPaging),
                _PageSize: 25,
                _PageCount: pageCount));
        }
        [HttpGet("GetUserEvent")]
        public IActionResult GetUserEvent([FromQuery]string q,int page)
        {
            var workEvent = uow.WorkEventRepository.GetUserWorkEvents(q);
            var pageCount = uow.Repository.GetPageCount(workEvent, 25);
            var notesPaging = uow.Repository.GetPaginate(workEvent, page, 25);
            return Ok(new ResultDTO<IQueryable<WorkEventDTO>>(
                _Data: uow.WorkEventRepository.ConvertWorkEvntModel(notesPaging),
                _PageSize: 25,
                _PageCount: pageCount));
        }
        [HttpPost("AddEvent")]
        public async Task<IActionResult> AddEvent(WorkEventDTO model)
        {
            await uow.WorkEventRepository.AddEvent(model);
            return Ok();
        }
        [HttpPut("UpdateEvent")]
        public async Task<IActionResult> UpdateEvent(WorkEventDTO model)
        {
            await uow.WorkEventRepository.UpdateEvent(model);
            return Ok();
        }

        [HttpPost("ShareGroup")]
        public async Task<IActionResult> ShareGroup(ShareGroupDTO share)
        {
            await uow.WorkEventRepository.ShareGroup(share.ObjectId, share.GroupIds);
            return Ok();
        }
        [HttpGet("TogleNotifiedMe/{ID}")]
        public async Task<IActionResult> TogleNotifiedMe(Guid ID)
        {
            await uow.WorkEventRepository.TogleNotifiedMe(ID,"");
            return Ok();
        }
        [HttpGet("TogleComplated/{ID}")]
        public async Task<IActionResult> TogleComplated(Guid ID)
        {
            await uow.WorkEventRepository.TogleComplated(ID);
            return Ok();
        }

    }
}
