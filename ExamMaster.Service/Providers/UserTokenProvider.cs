using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Service.Providers
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Concurrent;

    public class UserTokenProvider : IUserTokenProvider
    {
        private static readonly ConcurrentDictionary<(string user, string loginProvider, string name), TokenProviderValue> _tokenDictionary =
            new ConcurrentDictionary<(string user, string loginProvider, string name), TokenProviderValue>();


        public Task SetTokenAsync(string useremail, string loginProvider, string name, TokenProviderValue ? value, CancellationToken cancellationToken)
        {
            // Store the token based on the provided user, loginProvider, and name
            _tokenDictionary[(useremail, loginProvider, name)] = value ?? throw new UnauthorizedAccessException();
            return Task.CompletedTask;
        }

        public Task RemoveTokenAsync(string user, string loginProvider, string name, CancellationToken cancellationToken)
        {
            // Remove the token based on the provided user, loginProvider, and name
            _tokenDictionary.TryRemove((user, loginProvider, name), out _);
            return Task.CompletedTask;
        }

        public Task<TokenProviderValue?> GetTokenAsync(string user, string loginProvider, string name, CancellationToken cancellationToken)
        {
            // Retrieve the token based on the provided user, loginProvider, and name
            return Task.FromResult(_tokenDictionary.TryGetValue((user, loginProvider, name), out var token) ? token : null);
        }

      

        public void Dispose()
        {
           _tokenDictionary?.Clear();
        }

    }

}
