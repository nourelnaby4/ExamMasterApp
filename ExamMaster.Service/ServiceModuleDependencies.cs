﻿using ExamMaster.Application.Common.Model;
using ExamMaster.Application.Contracts;
using ExamMaster.Application.Contracts.IServices;
using ExamMaster.Application.Contracts.IServices.AuthServices;
using ExamMaster.Service.Authentications;
using ExamMaster.Service.Cache;
using ExamMaster.Service.Emails;
using ExamMaster.Service.Providers;
using Microsoft.AspNetCore.Identity.UI.Services;
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


            #region AuthService
            services.AddScoped<IAuthService, AuthService>();
            services.Configure<EmailSetting>(configuration.GetSection("EmailSetting"));
            services.AddScoped(typeof(CodeProvider));
            services.AddTransient<IEmailService, EmailService>();
            services.AddScoped<IUserTokenProvider, UserTokenProvider>();

            #endregion
            return services;
        }
    }
}
