using DapperExample.Data;
using DapperExample.Repositories.Fruits;
using DapperExample.Repositories.UnitOfWork;
using DapperExample.Services.Fruits;
using Microsoft.EntityFrameworkCore;

namespace DapperExample.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IFruitRepository, FruitRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<AppDbContext>(item => item.UseSqlServer(configuration.GetConnectionString("Db")));
            services.AddSingleton<DapperContext>();
            services.AddScoped<IFruitServices, FruitServices>();

            return services;
        }
    }
}
