using ExamMaster.Application.Behavior;
using ExamMaster.Application.Contracts.IServices;
using ExamMaster.Application.Features.Exams.Commands.Services;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ExamMaster.Application
{
    public static class ApplicationModuleDependecies
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assembly);
            services.AddMediatR(config => config.RegisterServicesFromAssemblies(assembly));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));   //validation behavior 

            services.AddScoped<IStudentExamFactory,StudentExamFactory>();
            services.AddScoped<IExamCalculator,ExamCalculator>();


        
            return services;
        }
    }
}
