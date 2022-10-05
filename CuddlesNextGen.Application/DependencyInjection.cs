using FluentValidation;
using MediatR;
using System.Reflection;
using CuddlesNextGen.Application.Service;
using Microsoft.Extensions.DependencyInjection;

namespace CuddlesNextGen.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
           // services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
             services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<IIdentityService, IdentityService>();
         // services.AddTransient<ITemplateMapper, TemplateMapper>();
            services.AddSingleton<ICustomMessageService, CustomMessageService>();
          ///  services.AddScoped<IAzureService, AzureService>();
            return services;
        }
    }
}
