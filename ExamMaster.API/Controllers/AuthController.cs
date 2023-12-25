using ExamMaster.API.Base;
using ExamMaster.Application.Features.Authentications.Models.Requests;
using ExamMaster.Application.Features.Exams.Queries.Models.Requests;
using ExamMaster.Domain.MetaData;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamMaster.API.Controllers
{
    [Route(Routing.root+"/auth")]
    [ApiController]
    public class AuthController : ControllerMain
    {
        #region fields
        private readonly IMediator _mediator;
        #endregion


        #region constructors
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion


        #region actions

        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn([FromBody] SignInRequest request)
        {
            var result = await _mediator.Send(request);
            return GetResponse(result);
        }
    }
    #endregion
}
