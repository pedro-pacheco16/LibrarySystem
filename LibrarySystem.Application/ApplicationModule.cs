﻿using LibrarySystem.Application.Command.CreateBook;
using Microsoft.Extensions.DependencyInjection;

namespace LibrarySystem.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddHandlers();

            return services;
        }
        private static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            config.RegisterServicesFromAssemblyContaining<CreateBookCommand>());

            return services;
        }
    }
}
