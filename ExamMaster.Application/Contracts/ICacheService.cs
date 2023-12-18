using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Contracts
{
    public interface ICacheService
    {
       Task< T >Get<T>(string key, Func<Task<T>> GetFromDB);
        void Set<T>(string key, T value);
        Task<T> Get<T>(string key);
        void Update<T>(string key, T value);
        Task Remove(string key);
    }
}
