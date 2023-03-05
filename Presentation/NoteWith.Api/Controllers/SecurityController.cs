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
    public class SecurityController : BaseController
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
            try
            {
                var resultModel = await security.Register(model);
                return Ok(new ResultDTO<LoginResultModel>(_Data:resultModel));
            }
            catch (Exception ex)
            {
                return ErrorHadler(ex);
            }
            
        }
        [HttpPost("ConfirmeEmil")]
        public async Task<IActionResult>EmailConfirme(EmailConfirmeDTO model)
        {
            try
            {
                await security.ConfirmeEmil(model);

                return Ok(new ResultDTO<int>(1));
            }
            catch (Exception ex)
            {
                return ErrorHadler(ex);
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            try
            {
                var resultModel = await security.Login(model);

                return Ok(new ResultDTO<LoginResultModel>(_Data: resultModel));
            }
            catch (Exception ex)
            {
                return ErrorHadler(ex);
            }
        }
        [HttpGet("SendResetPasswordEmail/{email}")]
        public async Task<IActionResult> SendResetPasswordEmail(string email)
        {
            try
            {
                await security.SendResetPasswordEmail(email);
                return Ok(new ResultDTO<int>(0));
            }
            catch (Exception ex)
            {
                return ErrorHadler(ex);
            }
        }
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(EmailConfirmeDTO model)
        {
            try
            {
                await security.ResetPassword(model);

                return Ok(new ResultDTO<int>(1));
            }
            catch (Exception ex)
            {
                return ErrorHadler(ex);
            }
        }

    }
}

