using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteWith.Application.Repositorys;
using NoteWith.Domain.DTOModels.BaseModel;
using NoteWith.Domain.DTOModels.GroupModels;

namespace NoteWith.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GroupController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        public GroupController(IUnitOfWork _uow)
        {
            uow= _uow;
        }
        [HttpGet("GetUserGroup")]
        public async Task<IActionResult> GetUserGroup()
        {
            return Ok(new ResultDTO<IQueryable<GroupListDTO>>(_Data:await uow.GroupRepository.GetUserGroup()));
        }
        [HttpPost("AddWorkGroup")]
        public async Task<IActionResult> AddGroup([FromBody]GroupDTO model)
        {
            await uow.GroupRepository.AddGuop(model);
            return Ok();
        }
        [HttpPut("EditGroup")]
        public async Task<IActionResult> EditGroup([FromBody]GroupDTO model)
        {
            await uow.GroupRepository.EditGroup(model);
            return Ok();
        }
        [HttpDelete("DeleteGroup/{Id}")]
        public async Task<IActionResult>DeleteGroup(Guid Id)
        {
            await uow.GroupRepository.DeleteGroup(Id);
            return Ok();
        }

        [HttpGet("GetShareCode/{Id}")]
        public async Task<IActionResult> GetShareCode(Guid Id)=>
            Ok(new ResultDTO<string>(_Data: await uow.GroupRepository.GenerateShareGroupKey(Id)));

        [HttpGet("JoinGroup/{key}")]
        public async Task<IActionResult>JoinGroup(string key)
        {
            await uow.GroupRepository.JoinWorkGroupWithAccesKey(key);
            return Ok();
        }
        [HttpGet("LeaveGroup/{Id}")]
        public async Task<IActionResult> LeaveGroup(Guid Id)
        {
            await uow.GroupRepository.LeaveGruop(Id);
            return Ok();
        }
        [HttpGet("SetNuteGroupTougle/{Id}")]
        public async Task<IActionResult> SetNuteGroupTougle(Guid Id)
        {
            await uow.GroupRepository.SetNuteTogle(Id);
            return Ok();
        }

    }
}
