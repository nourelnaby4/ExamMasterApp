using AVMS.Application.Common.Model;
using ExamMaster.Application.Contracts.IServices.AuthServices;
using ExamMaster.Application.Features.Authentications.Models.Requests;
using ExamMaster.Application.Features.Authentications.Models.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Authentications.Handler
{
    public class AuthHandler:ResponseHandler, IRequestHandler<SignInRequest, Response<TokenModelResponse>>
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
    }
}
