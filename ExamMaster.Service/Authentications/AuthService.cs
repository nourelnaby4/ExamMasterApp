using AVMS.Application.Common.Model;
using ExamMaster.Application.Common.Enums.Constents;
using ExamMaster.Application.Common.Model;
using ExamMaster.Application.Contracts;
using ExamMaster.Application.Contracts.IServices.AuthServices;
using ExamMaster.Application.Contracts.Repos;
using ExamMaster.Application.Features.Authentications.Models.Requests;
using ExamMaster.Domain.Entities;
using ExamMaster.Service.Providers;
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

namespace ExamMaster.Service.Authentications
{
    public class AuthService :ResponseHandler, IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork _repos;
        private readonly JWT _jwt;
        private readonly CodeProvider _codeProvider;
        private readonly IEmailService _emailService;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AuthService(UserManager<ApplicationUser> userManager,
            IOptions<JWT> jwt,
            RoleManager<IdentityRole> roleManager,
            CodeProvider codeProvider,
            IEmailService emailService,
            IUnitOfWork repos)
        {
            _userManager = userManager;
            _jwt = jwt.Value;
            _codeProvider = codeProvider;
            _emailService = emailService;
            _roleManager = roleManager;
            _repos = repos;
        }
        public async Task<AuthModel> SignInAsync(SignInRequest model)
        {

            var user = await _userManager.FindByNameAsync(model.Username);
            user = user ?? await _userManager.FindByEmailAsync(model.Username);

            if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                return new AuthModel { IsAuthenticated = false, Message = "Username or Password is incorrect!" };

            }

            var jwtSecurityToken = await CreateJwtToken(user);
            var rolesList = await _userManager.GetRolesAsync(user);
            var authModel = await CreateAuthModel(user, rolesList, jwtSecurityToken);
            return authModel;


        }

        public async Task<Response<string>> ChangePasswordAsync(string userId, string oldPassword, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return BadRequest<string>("user not registerd");

            var passwordChangeResult = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
            if (!passwordChangeResult.Succeeded)
            {
                return BadRequest<string>("Failed to change password");
            }

            return Success<string>("success");
        }


        public async Task<Response<string>> ForgetPasswordAsync(string email)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(email);

                if (user is null) return BadRequest<string>("email is not found");

                var resetToken = await _codeProvider.GenerateAsync("ResetPassword", _userManager, user);

                var subject = "Password Reset Request";
                var message = $"keep this code secured to reset your password: {resetToken}";

                await _emailService.SendEmailAsync(email, subject, message);

                return Success<string>("success");
            }
            catch (Exception ex)
            {
                return BadRequest<string>(ex.Message);
            }

        }


        public async Task<Response<string>> ResetPassword(string ResetCode, string email, string newPassword)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user is null) return BadRequest<string>("email is not found");

            var vaildCode = await _codeProvider.ValidateAsync("ResetPassword", ResetCode, _userManager, user);
            if (!vaildCode) return BadRequest<string>("email or resetCode is not valid");

            var result = await _userManager.ResetPasswordAsync(user, ResetCode, newPassword);
            if (!result.Succeeded) return BadRequest<string>("faild to reset password");
            return Success<string>("success");

        }

        public async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var claims = await CreateUserClaims(user);

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
        public async Task<IEnumerable<Claim>> CreateUserClaims(ApplicationUser user)
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
                new Claim(nameof(ClaimsEnum.UserId), user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            return claims;
        }
        public async Task<AuthModel> CreateAuthModel(ApplicationUser user, IEnumerable<string> roles, JwtSecurityToken jwtSecurityToken)
        {
            AuthModel authModel = new();
            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authModel.Email = user.Email;
            authModel.Username = user.UserName;
            authModel.ExpiresOn = jwtSecurityToken.ValidTo;
            authModel.Roles = roles.ToList();

            return authModel;
           

        }
        public string GetUserId(ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.FindFirst(nameof(ClaimsEnum.UserId))?.Value;
        }
        public string GetClaimByType(ClaimsPrincipal claimsPrincipal, string claimType)
        {
            return claimsPrincipal.FindFirst(claimType)?.Value;
        }
        public Dictionary<string, string> GetAllUserClaims(ClaimsPrincipal claimsPrincipal)
        {
            var dictionaty = new Dictionary<string, string>();
            foreach (var claim in claimsPrincipal.Claims)
            {
                dictionaty.Add(claim.Type, claim.Value);
            }
            return dictionaty;
        }
    }
}
