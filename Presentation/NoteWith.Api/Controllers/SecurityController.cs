using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NoteWith.Application.Repositorys;
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
                return Ok(resultModel);
            }
            catch (Exception ex)
            {
                return ErrorHadler(ex);
            }
            
        }

    }
}

