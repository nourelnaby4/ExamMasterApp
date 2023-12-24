using ExamMaster.Application.Features.Authentications.Models.Requests;
using ExamMaster.Application.Features.Students.Commands.Models.Requests;
using ExamMaster.Application.Features.Students.Commands.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Contracts.IServices
{
    public interface IAuthStudentService 
    {
        Task<StudentAuthModel> RegisterAsync(StudentRegistrationRequest registerModel);
        Task<StudentAuthModel> SignInAsync(SignInRequest signInModel);
    }
}
