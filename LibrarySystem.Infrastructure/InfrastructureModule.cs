using LibrarySystem.Core.Common.Interfaces;
using LibrarySystem.Core.Repositories;
using LibrarySystem.Core.Settings;
using LibrarySystem.Infrastructure.Persistence;
using LibrarySystem.Infrastructure.Repositories;
using LibrarySystem.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
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
            services
                .AddRepositories()
                .AddData(configuration);

            return services;
        }
        
        public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("LibrarySystemCs");

            services.AddDbContext<LibrarySystemDbContext>(o => o.UseSqlServer(connectionString));

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILoanRepository, LoanRepository>();

            return services;
        }
    }
}
