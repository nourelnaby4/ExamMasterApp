using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Contracts
{
    public interface ICacheService
    {
        TItem Get<TItem>(string key);
        void Set<TItem>(string key, TItem value);
        void Update<TItem>(string key, TItem value);
        void Remove(string key);
    }
}
