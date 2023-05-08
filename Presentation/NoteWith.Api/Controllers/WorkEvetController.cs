using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NoteWith.Application.Repositorys;
using NoteWith.Domain.DTOModels.BaseModel;
using NoteWith.Domain.DTOModels.EventModels;
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
    }
}
