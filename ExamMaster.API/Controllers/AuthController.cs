using ExamMaster.API.Base;
using ExamMaster.Application.Common.Enums.Constents;
using ExamMaster.Application.Features.Authentications.Models.Requests;
using ExamMaster.Application.Features.Authentications.Models.ViewModels;
using ExamMaster.Application.Features.Exams.Queries.Models.Requests;
using ExamMaster.Domain.MetaData;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        [AllowAnonymous]
        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn([FromBody] SignInRequest request)
        {
            var result = await _mediator.Send(request);
            return GetResponse(result);
        }
        [Authorize]
        [HttpPut("change-password")]
        public async Task<IActionResult> ChangePasswordAsync([FromBody] ChangePasswordViewModel model)
        {
            ChangePasswordRequest request = new(model, User);
            var result = await _mediator.Send(request);
            return GetResponse(result);
        }
        [HttpPost("forget-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgetPassword([FromBody] ForgetPasswordRequest model)
        {
            var result = await _mediator.Send(model);
            return GetResponse(result);
        }

        [HttpPost("reset-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest model)
        {
            var result = await _mediator.Send(model);
            return GetResponse(result);
        }
    }
    #endregion
}
