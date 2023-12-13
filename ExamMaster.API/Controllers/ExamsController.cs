using ExamMaster.API.Base;
using ExamMaster.Application.Features.Exams.Commands.Models;
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
        #endregion
    }
}
