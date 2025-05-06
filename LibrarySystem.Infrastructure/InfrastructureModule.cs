using LibrarySystem.Core.Common.Interfaces;
using LibrarySystem.Core.Settings;
using LibrarySystem.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace LibrarySystem.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SmtpSettings>(configuration.GetSection("SmtpSettings"));
            services.AddScoped<IEmailService, SmtpEmailService>();
            return services;
        }
    }
}
