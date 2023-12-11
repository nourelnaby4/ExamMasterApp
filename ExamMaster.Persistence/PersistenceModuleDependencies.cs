
using ExamMaster.Application.Contracts;
using ExamMaster.Domain.Entities;
using ExamMaster.Persistence.Context;
using ExamMaster.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace ExamMaster.Persistence
{
    public static class PersistenceModuleDependencies
    {
        public static IServiceCollection AddPersistenceDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient(typeof(IBaseRepo<>), typeof(BaseRepo<>));
            return services;
        }
    }
}
