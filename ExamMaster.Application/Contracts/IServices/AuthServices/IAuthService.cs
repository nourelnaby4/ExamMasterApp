using AVMS.Application.Common.Model;
using ExamMaster.Application.Common.Model;
using ExamMaster.Application.Features.Authentications.Models.Requests;
using ExamMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Contracts.IServices.AuthServices
{
    public interface IAuthService
    {
        Task<AuthModel> SignInAsync(SignInRequest model);
        Task<Response<string>> ForgetPasswordAsync(string email);
        Task<Response<string>> ChangePasswordAsync(string userId, string oldPassword, string newPassword);
        Task<Response<string>> ResetPassword(string ResetCode, string email, string newPassword);
        Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user);
        Task<IEnumerable<Claim>> CreateUserClaims(ApplicationUser user);
        Task<AuthModel> CreateAuthModel(ApplicationUser user, IEnumerable<string> roles, JwtSecurityToken jwtSecurityToken);
        string GetUserId(ClaimsPrincipal claimsPrincipal);
        string GetClaimByType(ClaimsPrincipal claimsPrincipal, string claimType);
        Dictionary<string, string> GetAllUserClaims(ClaimsPrincipal claimsPrincipal);
    }
}
