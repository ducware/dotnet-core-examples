using JWT_Authentication_and_Authorization_Role_Based.Services;

namespace JWT_Authentication_and_Authorization_Role_Based
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthServices, AuthServices>();
            return services;
        }
    }
}
