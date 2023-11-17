using FluentValidation;
using MinimalAPI.CouponApi.Configs;

namespace MinimalAPI.CouponApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingConfig));
            services.AddValidatorsFromAssemblyContaining<Program>();

            return services;
        }
    }
}
