using FluentValidation;
using FluentValidation.AspNetCore;
using LibrarySystem.Application.Command.CreateBook;
using LibrarySystem.Application.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace LibrarySystem.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddHandlers()
                .AddValidator();

            return services;
        }
        private static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            config.RegisterServicesFromAssemblyContaining<CreateBookCommand>());

            return services;
        }

        public static IServiceCollection AddValidator(this IServiceCollection services)
        {
            services
                .AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<CreateBookValidator>();

            return services;
        }
    }
}
