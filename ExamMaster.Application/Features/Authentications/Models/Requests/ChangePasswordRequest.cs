using AVMS.Application.Common.Model;
using ExamMaster.Application.Features.Authentications.Models.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Authentications.Models.Requests
{
    public class ChangePasswordRequest : IRequest<Response<string>>
    {
        public ChangePasswordViewModel Model { get; private set; }
        public ClaimsPrincipal User { get; private set; }

        public ChangePasswordRequest(ChangePasswordViewModel model, ClaimsPrincipal user)
        {
            Model = model;
            User = user;
        }
    }
}
