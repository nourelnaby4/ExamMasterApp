using ExamMaster.Application.Contracts;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Cache
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IConfiguration _configuration;

        public CacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public TItem Get<TItem>(string key)
        {
            var item=  _memoryCache.Get<TItem>(key);
            return item is null ? item : (TItem)item;
         
        }

        
        public void Set<TItem>(string key, TItem value)
        {

            _memoryCache.Set(key, value);
        }
        public void Update<TItem>(string key,TItem value)
        {
            _memoryCache.Remove(key);
            _memoryCache.Set(key, value);
        }
        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }
    }
}
