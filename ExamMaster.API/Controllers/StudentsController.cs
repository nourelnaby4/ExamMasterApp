using ExamMaster.API.Base;
using ExamMaster.Application.Features.Authentications.Models.Requests;
using ExamMaster.Application.Features.Exams.Commands.Models;
using ExamMaster.Application.Features.Students.Commands.Models.Requests;
using ExamMaster.Domain.MetaData;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamMaster.API.Controllers
{
    [Route(Routing.root + "/student")]
    [ApiController]
    public class StudentsController : ControllerMain
    {
        #region fields
        private readonly IMediator _mediator;
        #endregion


        #region constructors
        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion


        #region endpoints
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] StudentRegistrationRequest request)
        {
            var result = await _mediator.Send(request);
            return GetResponse(result);
        }
        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn([FromBody] SignInRequest request)
        {
            var result = await _mediator.Send(request);
            return GetResponse(result);
        }



        #endregion

    }
}
