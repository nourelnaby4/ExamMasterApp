using ExamMaster.Application.Common.Model;
using ExamMaster.Application.Contracts.IServices.AuthServices;
using ExamMaster.Application.Contracts.Repos;
using ExamMaster.Application.Features.Authentications.Models.Requests;
using ExamMaster.Application.Features.Students.Commands.Models.Requests;
using ExamMaster.Application.Features.Students.Commands.Models.ViewModel;
using ExamMaster.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Students.Services
{
    public class AuthStudentService : IAuthStudentService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthService _authService;
        private readonly IUnitOfWork _repos;
        public AuthStudentService(UserManager<ApplicationUser> userManager,IAuthService authService, IUnitOfWork repos)
        {
            _userManager = userManager;
            _authService = authService;
            _repos = repos;
        }

        public async Task<StudentAuthModel> RegisterAsync(StudentRegistrationRequest StudentRegistrationRequest)
        {
            if (await _userManager.FindByEmailAsync(StudentRegistrationRequest.Email) is not null)
            {
                return new StudentAuthModel { Message = "Email is already registered!" };
            }

            if (await _userManager.FindByNameAsync(StudentRegistrationRequest.Username) is not null)
            {
                return new StudentAuthModel { Message = "Username is already registered!" };
            }

            var transaction = _repos.BeginTransaction();

            var user = await CreateStudentUser(StudentRegistrationRequest);
            var createRole = await _userManager.AddToRoleAsync(user, "Student");
            if (!createRole.Succeeded)
            {
                transaction.Rollback();
            }
        
            var jwtSecurityToken = await _authService.CreateJwtToken(user);
           
            var authModel = await _authService.CreateAuthModel(user, new string[] { "Student" }, jwtSecurityToken);
            transaction.Commit();
            return authModel;
        }
       
       public async Task<ApplicationUser> CreateStudentUser(StudentRegistrationRequest student)
        {
            var user = new ApplicationUser
            {
                UserName = student.Username,
                Email = student.Email,

            };
            var result = await _userManager.CreateAsync(user, student.Password);
            if (!result.Succeeded)
            {
                string errors = string.Empty;
                foreach (var error in result.Errors)
                {
                    errors += $"{error.Description} ,";
                }
                throw new InvalidDataException(errors);
            }
            return user;
        }
    }
}
