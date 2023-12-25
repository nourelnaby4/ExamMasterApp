using ExamMaster.Application.Common.Model;
using ExamMaster.Application.Contracts.IServices.AuthServices;
using ExamMaster.Application.Contracts.Repos;
using ExamMaster.Application.Features.Authentications.Models.Requests;
using ExamMaster.Application.Features.Admins.Commands.Models.Requests;
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
using ExamMaster.Application.Common.Enums.Constents;

namespace ExamMaster.Application.Features.Admins.Services
{
    public class AuthAdminService : IAuthAdminService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthService _authService;
        private readonly IUnitOfWork _repos;
        public AuthAdminService(UserManager<ApplicationUser> userManager,IAuthService authService, IUnitOfWork repos)
        {
            _userManager = userManager;
            _authService = authService;
            _repos = repos;
        }

        public async Task<AuthModel> RegisterAsync(AdminRegistrationRequest AdminRegistrationRequest)
        {
          

            var transaction = _repos.BeginTransaction();
            var role = nameof(RoleEnum.Admin);
            var user = await CreateAdminUser(AdminRegistrationRequest);
            var createRole = await _userManager.AddToRoleAsync(user, role);
            if (!createRole.Succeeded)
            {

                transaction.Rollback();
                throw new InvalidDataException($"{role} is not exist");
            }
        
            var jwtSecurityToken = await _authService.CreateJwtToken(user);
           
            var authModel = await _authService.CreateAuthModel(user, new string[] { role }, jwtSecurityToken);
            transaction.Commit();
            return authModel;
        }
       
       public async Task<ApplicationUser> CreateAdminUser(AdminRegistrationRequest Admin)
        {
            var user = new ApplicationUser
            {
                UserName = Admin.Username,
                Email = Admin.Email,

            };
            var result = await _userManager.CreateAsync(user, Admin.Password);
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
