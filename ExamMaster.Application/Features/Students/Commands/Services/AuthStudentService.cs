using ExamMaster.Application.Common.Model;
using ExamMaster.Application.Contracts.IServices;
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
        private readonly IUnitOfWork _repos;
        private readonly JWT _jwt;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AuthStudentService(UserManager<ApplicationUser> userManager, IOptions<JWT> jwt, RoleManager<IdentityRole> roleManager, IUnitOfWork repos)
        {
            _userManager = userManager;
            _jwt = jwt.Value;
            _roleManager = roleManager;
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
            var user = new ApplicationUser
            {
                UserName = StudentRegistrationRequest.Username,
                Email = StudentRegistrationRequest.Email,

            };
            // for hashing password
            var result = await _userManager.CreateAsync(user, StudentRegistrationRequest.Password);
            if (!result.Succeeded)
            {
                string errors = string.Empty;
                foreach (var error in result.Errors)
                {
                    errors += $"{error.Description} ,";
                }
                return new StudentAuthModel { Message = errors };
            }


            var createRole = await _userManager.AddToRoleAsync(user, "Student");
            if (!createRole.Succeeded)
            {
                transaction.Rollback();
            }
        
            var jwtSecurityToken = await CreateJwtToken(user);
            var authModel= new StudentAuthModel
            {
                IsAuthenticated = true,
                ExpiresOn = jwtSecurityToken.ValidTo,
                Username = user.UserName,
                Roles = new List<string> { "Student" },
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)


            };
            transaction.Commit();
            return authModel;
        }
        public async Task<StudentAuthModel> SignInAsync(SignInRequest model)
        {
            var StudentAuthModel = new StudentAuthModel();

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                StudentAuthModel.Message = "Email or Password is incorrect!";
                return StudentAuthModel;
            }

            var jwtSecurityToken = await CreateJwtToken(user);
            var rolesList = await _userManager.GetRolesAsync(user);

            StudentAuthModel.IsAuthenticated = true;
            StudentAuthModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            StudentAuthModel.Email = user.Email;
            StudentAuthModel.Username = user.UserName;
            StudentAuthModel.ExpiresOn = jwtSecurityToken.ValidTo;
            StudentAuthModel.Roles = rolesList.ToList();

            return StudentAuthModel;
        }
        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jwt.DurationInDays),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
    }
}
