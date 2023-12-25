using ExamMaster.Application.Common.Model;
using ExamMaster.Application.Features.Admins.Commands.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Contracts.IServices.AuthServices
{
    public interface IAuthAdminService
    {
        Task<AuthModel> RegisterAsync(AdminRegistrationRequest registerModel);
    }
}
