using ExamMaster.API.Base;
using ExamMaster.Application.Features.Questions.MultiChoice.Commands.Models.Requsets;
using ExamMaster.Domain.MetaData;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamMaster.API.Controllers
{
    [Route(Routing.root+"/question")]
    [Authorize]
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
       

        [HttpPost("multiChoice")]
        public async Task<IActionResult> Create(MultiChoiceCreateRequest request)
        {
            var result = await _mediator.Send(request);
            return GetResponse(result);
        }
        [HttpPut("multiChoice/{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id,[FromBody] MultiChoiceEditRequest request)
        {
            if (request.QuestionId != id) return BadRequest();
            var result = await _mediator.Send(request);
            return GetResponse(result);
        }
        [HttpDelete("multiChoice/{id}")]
        public async Task<IActionResult> Delete( [FromRoute] int id)
        {
            var result = await _mediator.Send(new MultiChoiceDeleteRequest(id));
            return GetResponse(result);
        }
        #endregion
    }

}
