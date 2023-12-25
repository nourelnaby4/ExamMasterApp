using ExamMaster.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Service.Providers
{
    public class CodeProvider : IUserTwoFactorTokenProvider < ApplicationUser>
    {
        private readonly IUserTokenProvider _userTokenStore;

        public CodeProvider(IUserTokenProvider userTokenStore)
        {
            _userTokenStore = userTokenStore;
        }

        public Task<bool> CanGenerateTwoFactorTokenAsync(UserManager<ApplicationUser> manager, ApplicationUser user)
        {
            // Implement your logic for checking if a two-factor token can be generated
            throw new NotImplementedException();
        }

        public async Task<string> GenerateAsync(string purpose, UserManager<ApplicationUser> manager, ApplicationUser user)
        {
            string sixDigitToken = GenerateSixDigitToken();
            CancellationToken cancellationToken = default; // Provide the appropriate cancellation token if needed

            await _userTokenStore.SetTokenAsync(user.Email, "CodeProvider", purpose, new TokenProviderValue { Value = sixDigitToken }, cancellationToken);
            return sixDigitToken;
        }

        public async Task<bool> ValidateAsync(string purpose, string token, UserManager<ApplicationUser> manager, ApplicationUser user)
        {
            CancellationToken cancellationToken = default; // Provide the appropriate cancellation token if needed

            var storedToken = await _userTokenStore.GetTokenAsync(user.Email, "CodeProvider", purpose, cancellationToken);
            return storedToken != null && token ==(string) storedToken.Value && storedToken.IsValid;
        }

        private string GenerateSixDigitToken()
        {
            Random random = new Random();
            int tokenValue = random.Next(100000, 999999); // Generate a random 6-digit number
            return tokenValue.ToString();
        }
    }

}
