﻿using ExamMaster.API.Base;
using ExamMaster.Application.Features.Questions.MultiChoice.Commands.Models.Requsets;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamMaster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerMain
    {

        #region fields
        private readonly IMediator _mediator;
        #endregion


        #region constructor
        public QuestionsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region endpoints
       

        [HttpPost("MultiChoice")]
        public async Task<IActionResult> Create(MultiChoiceCreateRequest request)
        {
            var result = await _mediator.Send(request);
            return GetResponse(result);
        }
        [HttpPut("MultiChoice")]
        public async Task<IActionResult> Edit([FromBody] MultiChoiceEditRequest request, [FromQuery] int questionId)
        {
            if (request.QuestionId != questionId) return BadRequest();
            var result = await _mediator.Send(request);
            return GetResponse(result);
        }
        [HttpDelete("MultiChoice")]
        public async Task<IActionResult> Delete( [FromQuery] int questionId)
        {
            var result = await _mediator.Send(new MultiChoiceDeleteRequest(questionId));
            return GetResponse(result);
        }
        #endregion
    }

}