using ExamMaster.Application.Contracts;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ExamMaster.Service.Cache
{

    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IConfiguration _configuration;

        public CacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public async Task<T> Get<T>(string key, Func<Task<T>> GetFromDB)
        {
            var item = await Task.Run(() => _memoryCache.Get<T>(key));

            T result;
            if (item != null)
            {
                result = (T)item;
            }
            else
            {
                result = await GetFromDB();
                _memoryCache.Set(key, result);
            }

            return result;
        }
        public async Task<T> Get<T>(string key)
        {
            var item = await Task.Run(() => _memoryCache.Get<T>(key));

            return item;
        }

            public void Set<T>(string key, T value)
        {
            _memoryCache.Set(key, value);
        }
        public void Update<T>(string key, T value)
        {
            _memoryCache.Remove(key);
            _memoryCache.Set(key, value);
        }
        public async Task Remove(string key)
        {
           await Task.Run(()=> _memoryCache.Remove(key));
        }
    }
}