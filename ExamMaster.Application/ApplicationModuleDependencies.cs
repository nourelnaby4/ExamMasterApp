using MediatR;
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
           // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));   //validation behavior 


            return services;
        }
    }
}
