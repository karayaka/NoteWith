using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NoteWith.Application.Repositorys;
using NoteWith.Domain.DTOModels.BaseModel;
using NoteWith.Domain.DTOModels.SecurityModels;


namespace NoteWith.Api.Controllers
{
    [Route("api/[controller]")]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityRepository security;
        public SecurityController(ISecurityRepository _security)
        {
            security = _security;
        }
        // GET: api/values
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            
            var resultModel = await security.Register(model);
            return Ok(new ResultDTO<LoginResultModel>(_Data:resultModel));

        }
        [HttpPost("ConfirmeEmil")]
        public async Task<IActionResult>EmailConfirme([FromBody]EmailConfirmeDTO model)
        {

            await security.ConfirmeEmil(model);

            return Ok(new ResultDTO<int>(1));

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {
          
            var resultModel = await security.Login(model);

            return Ok(new ResultDTO<LoginResultModel>(_Data: resultModel));

        }
        [HttpGet("SendResetPasswordEmail/{email}")]
        public async Task<IActionResult> SendResetPasswordEmail(string email)
        {

            await security.SendResetPasswordEmail(email);
            return Ok(new ResultDTO<int>(0));
        }
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] EmailConfirmeDTO model)
        {
           
            await security.ResetPassword(model);

            return Ok(new ResultDTO<int>(1));

        }
        [HttpPost("GoogleLogin")]
        public async Task<IActionResult> GoogleLogin([FromBody] RegisterDTO model)
        {
            await security.GoogleLogin(model);

            return Ok(new ResultDTO<int>(1));
        }
    }
}

