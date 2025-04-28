using LibrarySystem.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LibrarySystem.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddServices();

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ILoanService, LoanService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
