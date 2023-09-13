using DemoCache.Core.Interfaces;
using DemoCache.Infrastructure.Data;
using DemoCache.Infrastructure.Repositories;
using DemoCache.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DemoCache.Infrastructure.ServiceExtension
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApiDbContext>(opt =>
                opt.UseNpgsql(configuration.GetConnectionString("DbConnection")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddSingleton(configuration.GetValue<string>("Redis"));

            return services;
        }
    }
}
