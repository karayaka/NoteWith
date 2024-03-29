﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NoteWith.Application.Repositorys;
using NoteWith.Domain.DTOModels.BaseModel;
using NoteWith.Domain.DTOModels.EventModels;
using NoteWith.Domain.DTOModels.NoticeModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NoteWith.Api.Controllers
{
    [Route("api/[controller]")]
    public class NoticeController : Controller
    {
        private readonly IUnitOfWork uow;
        public NoticeController(IUnitOfWork _uow)
        {
            uow = _uow;
        }
        [HttpGet("GetNotices")]
        public async Task<IActionResult> GetNotices([FromQuery]string q)
        {
            var notices=await uow.NoticeRepository.GetNotices(q);
            return Ok(new ResultDTO<IQueryable<NoticeDTO>>(
                _Data: uow.NoticeRepository.ConvertModel(notices)));
        }
        [HttpGet("AddNotice")]
        public async Task<IActionResult>AddNotice(NoticeDTO model)
        {
            await uow.NoticeRepository.AddNotice(model);
            return Ok();
        }
        [HttpDelete("DeleteNotice/{Id}")]
        public async Task<IActionResult>DeleteNotice(Guid Id)
        {
            await uow.NoticeRepository.DeleteNotice(Id);
            return Ok();
        }

    }
}

