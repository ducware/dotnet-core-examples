using Application.Queries.Animals;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;

            services.AddMediatR(configuration =>
                configuration.RegisterServicesFromAssembly(assembly));

            services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

            services.AddValidatorsFromAssembly(assembly);

            services.AddAutoMapper(assembly);

            services.AddScoped<IAnimalServices, AnimalServices>();

            return services;
        }
    }
}
