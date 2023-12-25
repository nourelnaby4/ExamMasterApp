using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Service.Providers
{
    public interface IUserTokenProvider
    {
        Task SetTokenAsync(string user, string loginProvider, string name, TokenProviderValue value, CancellationToken cancellationToken);
        Task RemoveTokenAsync(string user, string loginProvider, string name, CancellationToken cancellationToken);
        Task<TokenProviderValue?> GetTokenAsync(string user, string loginProvider, string name, CancellationToken cancellationToken);
    }
}
