using ExamMaster.API.Base;
using ExamMaster.Application.Common.Enums.Constents;
using ExamMaster.Application.Features.Admins.Commands.Models.Requests;
using ExamMaster.Application.Features.Students.Commands.Models.Requests;
using ExamMaster.Domain.MetaData;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamMaster.API.Controllers
{
    [Route(Routing.root + "/admin")]
    [ApiController]
    public class AdminController : ControllerMain
    {
        #region fields
        private readonly IMediator _mediator;
        #endregion


        #region constructors
        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion


        #region endpoints
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AdminRegistrationRequest request)
        {
            var result = await _mediator.Send(request);
            return GetResponse(result);
        }




        #endregion

    }
}
