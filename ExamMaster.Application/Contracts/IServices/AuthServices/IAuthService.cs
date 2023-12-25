using ExamMaster.Application.Features.Authentications.Models.Requests;
using ExamMaster.Application.Features.Students.Commands.Models.ViewModel;
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
        Task<StudentAuthModel> SignInAsync(SignInRequest model);
        Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user);
        Task<IEnumerable<Claim>> CreateUserClaims(ApplicationUser user);
        Task<StudentAuthModel> CreateAuthModel(ApplicationUser user, IEnumerable<string> roles, JwtSecurityToken jwtSecurityToken);
        string GetUserId(ClaimsPrincipal claimsPrincipal);
        string GetClaimByType(ClaimsPrincipal claimsPrincipal, string claimType);
        Dictionary<string, string> GetAllUserClaims(ClaimsPrincipal claimsPrincipal);
    }
}
