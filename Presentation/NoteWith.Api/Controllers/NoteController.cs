using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NoteWith.Application.Repositorys;
using NoteWith.Domain.DTOModels.BaseModel;
using NoteWith.Domain.DTOModels.GroupModels;
using NoteWith.Domain.DTOModels.NoteModels;
using NoteWith.Domain.DTOModels.SecurityModels;
using NoteWith.Domain.EntitiyModels.NoteModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NoteWith.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class NoteController : Controller
    {
        private readonly IUnitOfWork uow;
        public NoteController(IUnitOfWork _uow)
        {
            uow=_uow;
        }
        // GET: api/values
        [HttpGet("GetAllNote")]
        public async Task<IActionResult> GetAllNote([FromQuery]int page,string q,List<Guid> groupId)
        {
            var notes= await uow.NoteRepository.GetAllNotes(q, groupId);
            var pageCount = uow.Repository.GetPageCount(notes, 25);
            var notesPaging = uow.Repository.GetPaginate(notes, page, 25);
            return Ok(new ResultDTO<IQueryable<NoteListDTO>>(
                _Data: uow.NoteRepository.ConverNoteModels(notesPaging),
                _PageSize:25,
                _PageCount:pageCount));
        }

        [HttpGet("GetUserNotes")]
        public async Task<IActionResult> GetUserNote([FromQuery]string q,int page)
        {
            var notes= uow.NoteRepository.GetUserNotes(q);
            var pageCount= uow.Repository.GetPageCount(notes, 25);
            var notesPaging = uow.Repository.GetPaginate(notes, page, 25);
            return Ok(new ResultDTO<IQueryable<NoteListDTO>>(
                _Data: uow.NoteRepository.ConverNoteModels(notesPaging),
                _PageSize: 25,
                _PageCount: pageCount));
        }
        [HttpGet("GetGroupNote")]
        public async Task<IActionResult> GetGroupNote([FromQuery]List<Guid> groupIds,string q,int page)
        {
            var notes = await uow.NoteRepository.GetGroupsNotes(q, groupIds);
            var pageCount = uow.Repository.GetPageCount(notes, 25);
            var notesPaging = uow.Repository.GetPaginate(notes, page, 25);
            return Ok(new ResultDTO<IQueryable<NoteListDTO>>(
                _Data: uow.NoteRepository.ConverNoteModels(notesPaging),
                _PageSize: 25,
                _PageCount: pageCount));
        }
        [HttpPost("AddNote")]
        public async Task<IActionResult> AddNote(NoteCreateDTO model)
        {
            await uow.NoteRepository.AddNote(model);
            await uow.SaveChange();
            return Ok();
        }
        [HttpPost("ShareGroup")]
        public async Task<IActionResult> ShareGroup(ShareGroupDTO share)
        {
            await uow.NoteRepository.ShareGroup(share.ObjectId, share.GroupIds);
            return Ok();
        }
        [HttpGet("TogleNotifiedMe/{ID}")]
        public async Task<IActionResult> TogleNotifiedMe(Guid ID)
        {
            await uow.NoteRepository.TogleNotifiedMe(ID);
            return Ok();
        }

        [HttpPost("LeaveGroup")]
        public async Task<IActionResult> LeaveGroup(LeaveGroupDTO leave)
        {
            await uow.NoteRepository.LeaveGroup(leave.GroupId, leave.ObjectId);
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("UpdateNote")]
        public async Task<IActionResult> UpdateNote([FromBody]NoteCreateDTO model)
        {
            await uow.NoteRepository.UpdateNote(model);
            await uow.SaveChange(); 
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await uow.NoteRepository.DeleteNote(id);
            await uow.SaveChange();
            return Ok();
        }
    }
}

