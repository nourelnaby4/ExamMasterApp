using Azure.Core;
using ExamMaster.API.Base;
using ExamMaster.Application.Features.Exams.Commands.Models.Requests;
using ExamMaster.Application.Features.Exams.Commands.Models.ViewModels;
using ExamMaster.Application.Features.Exams.Queries.Models.Requests;
using ExamMaster.Application.Features.Levels.Queries.Models.Requests;
using ExamMaster.Domain.MetaData;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamMaster.API.Controllers
{
    [Route(Routing.root + "/exam")]
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

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ExamGetAllRequest request)
        {

            var result = await _mediator.Send(request);
            return GetResponse(result);
        }
        [HttpGet("{id}/questions")]
        public async Task<IActionResult> GetQuestions([FromRoute] int id)
        {
            var result = await _mediator.Send(new ExamQuestionGroupingRequest(id));
            return GetResponse(result);
        }

        [HttpPost("{id}/submit-answers")]
        public async Task<IActionResult> SubmitAnswers([FromRoute] int id, [FromBody] ExamSubmitAnswerViewModel viewModel)
        {
            if(id != viewModel.ExamId) return BadRequest(id);
            var result = await _mediator.Send(new ExamSubmitAnswerRequest(User,viewModel));
            return GetResponse(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ExamCreateRequest request)
        {

            var result = await _mediator.Send(request);
            return GetResponse(result);
        }
     

        [HttpPut()]
        public async Task<IActionResult> Edit([FromBody] ExamEditRequest request)
        {

            var result = await _mediator.Send(request);
            return GetResponse(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {

            var result = await _mediator.Send(new ExamDeleteRequest(id));
            return GetResponse(result);
        }
        #endregion
    }
}
