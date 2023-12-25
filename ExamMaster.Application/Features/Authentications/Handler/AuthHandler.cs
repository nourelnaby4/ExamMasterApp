using AVMS.Application.Common.Model;
using ExamMaster.Application.Contracts.IServices.AuthServices;
using ExamMaster.Application.Features.Authentications.Models.Requests;
using ExamMaster.Application.Features.Authentications.Models.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Authentications.Handler
{
    public class AuthHandler: ResponseHandler,
                              IRequestHandler<SignInRequest, Response<TokenModelResponse>>,
                              IRequestHandler<ChangePasswordRequest, Response<string>>,
                              IRequestHandler<ForgetPasswordRequest, Response<string>>,
                              IRequestHandler<ResetPasswordRequest, Response<string>>

    {
        private readonly IAuthService _authService;
        public AuthHandler(IAuthService authService) { _authService = authService; }
        public async Task<Response<TokenModelResponse>> Handle(SignInRequest request, CancellationToken cancellationToken)
        {
            var result = await _authService.SignInAsync(request);
            if (!result.IsAuthenticated)
                return BadRequest<TokenModelResponse>(result.Message);

            TokenModelResponse response = new()
            {
                Token = result.Token,
                ExpiresOn = result.ExpiresOn
            };
            return Success(response);
        }
        public async Task<Response<string>> Handle(ChangePasswordRequest request, CancellationToken cancellationToken)
        {
            var userId = _authService.GetUserId(request.User);
            var result = await _authService.ChangePasswordAsync(userId, request.Model.OldPassword, request.Model.NewPassword);
            return result;
        }

        public async Task<Response<string>> Handle(ForgetPasswordRequest request, CancellationToken cancellationToken)
        {
            var result = await _authService.ForgetPasswordAsync(request.email);
            return result;
        }

        public async Task<Response<string>> Handle(ResetPasswordRequest request, CancellationToken cancellationToken)
        {
            var result = await _authService.ResetPassword(request.ResetCode, request.Email, request.NewPassword);
            return result;
        }
    }
}
