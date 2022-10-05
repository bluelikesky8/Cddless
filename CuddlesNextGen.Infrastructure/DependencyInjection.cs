using CuddlesNextGen.Application.SQL;
using CuddlesNextGen.Domain.Interface;
using CuddlesNextGen.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace CuddlesNextGen.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ISqlContext, SqlContext>();
            services.AddScoped<IAuthServiceRepository, AuthServiceRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEmailService, EmailService>();
           //  services.AddScoped<IDocumentRepository, DocumentRepository>();
     
            return services;
        }
    }
}
