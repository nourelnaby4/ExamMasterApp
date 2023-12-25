using AutoMapper;
using AVMS.Application.Common.Model;
using ExamMaster.Application.Common.Enums.Constents;
using ExamMaster.Application.Contracts.IServices.AuthServices;
using ExamMaster.Application.Contracts.Repos;
using ExamMaster.Application.Features.Authentications.Models.Requests;
using ExamMaster.Application.Features.Authentications.Models.Responses;
using ExamMaster.Application.Features.Exams.Commands.Models;
using ExamMaster.Application.Features.Admins.Commands.Models.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Admins.Commands.Handlers
{
    public class AdminCommandHandler : ResponseHandler,
                                         IRequestHandler<AdminRegistrationRequest,Response<TokenModelResponse>>
    {

        #region fields
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _repo;
        private readonly IAuthAdminService _authService;
        #endregion

        #region constructor
        public AdminCommandHandler(IMapper mapper, IUnitOfWork repo,IAuthAdminService authService)
        {
            _mapper = mapper;
            _repo = repo;
            _authService = authService;
        }

        #endregion




        #region handlers

       

        public async Task<Response<TokenModelResponse>> Handle(AdminRegistrationRequest request, CancellationToken cancellationToken)
        {
            var result = await _authService.RegisterAsync(request);
            if (!result.IsAuthenticated)
                return BadRequest<TokenModelResponse>(result.Message);

            TokenModelResponse response = new()
            {
                Token = result.Token,
                ExpiresOn = result.ExpiresOn
            };
            return Success(response);
        }
        #endregion
    }
}
