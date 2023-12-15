using ExamMaster.API.Base;
using ExamMaster.Application.Features.Questions.MultiChoices.Commands.Models.Requsets;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamMaster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChoiceQuestionsController : ControllerMain
    {

        #region fields
        private readonly IMediator _mediator;
        #endregion


        #region constructor
        public ChoiceQuestionsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region endpoints
        [HttpPost]
        public async Task<IActionResult> Create(MultiChoiceCreateRequest request)
        {
            var result = await _mediator.Send(request);
            return GetResponse(result);
        }
        #endregion
    }

}
