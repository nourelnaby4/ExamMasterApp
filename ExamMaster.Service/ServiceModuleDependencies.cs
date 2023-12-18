using ExamMaster.Application.Contracts;
using ExamMaster.Service.Cache;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Service
{
    public static class ServiceModuleDependencies
    {
        public static IServiceCollection AddServiceModuleDependencies(this IServiceCollection services, IConfiguration configuration)
        {

            #region cache in-memory

            var cacheExpirationMinutes = configuration.GetSection("CacheSettings").GetValue<int>("DefaultCacheExpirationMinutes");
            services.AddScoped<ICacheService, CacheService>();

            //   AddMemoryCache to use private readonly IMemoryCache _memoryCache
            services.AddMemoryCache(options =>
            {
                options.ExpirationScanFrequency = TimeSpan.FromMinutes(5); // Optional: Set the frequency for scanning expired items
            });

            services.Configure<MemoryCacheEntryOptions>(options =>
            {
                options.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(cacheExpirationMinutes); // Set default expiration time to 30 minutes
            });

            #endregion
            return services;
        }
    }
}
