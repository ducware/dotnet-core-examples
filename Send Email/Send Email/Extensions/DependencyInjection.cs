using Send_Email.Services;

namespace Send_Email.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services, IConfiguration configuration)
        {
            // DI Services
            services.AddScoped<IEmailService, EmailService>();

            return services;
        }

    }
}
