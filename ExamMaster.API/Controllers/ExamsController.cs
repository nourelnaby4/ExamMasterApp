﻿using ExamMaster.API.Base;
using ExamMaster.Application.Features.Exams.Commands.Models;
using ExamMaster.Application.Features.Exams.Queries.Models.Requests;
using ExamMaster.Application.Features.Levels.Queries.Models.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamMaster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerMain
    {

        #region fields
        private readonly IMediator _mediator;
        #endregion


        #region constructors
        public ExamsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion


        #region actions
        [HttpGet("get-byId")]
        public async Task<IActionResult> Get([FromQuery] int ExamId)
        {

            var result = await _mediator.Send(new ExamGetByIdRequest(ExamId));
            return GetResponse(result);
        }
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery] int subjectId,int? levelId)
        {

            var result = await _mediator.Send(new ExamGetAllRequest(subjectId,levelId));
            return GetResponse(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ExamCreateRequest request)
        {

            var result = await _mediator.Send(request);
            return GetResponse(result);
        }

        [HttpPut("edit")]
        public async Task<IActionResult> Edit([FromBody] ExamEditRequest request)
        {

            var result = await _mediator.Send(request);
            return GetResponse(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] int ExamId)
        {

            var result = await _mediator.Send(new ExamDeleteRequest(ExamId));
            return GetResponse(result);
        }
        #endregion
    }
}
