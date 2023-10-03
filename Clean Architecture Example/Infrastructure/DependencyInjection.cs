using Domain.Common;
using Domain.Entities.Animal;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(item => item.UseSqlServer(configuration.GetConnectionString("Db")));
            services.AddSingleton<SqlConnectionFactory>();
            services.AddScoped<IAnimalRepository, AnimalRepository>();
            services.AddTransient<ISqlConnectionFactory, SqlConnectionFactory>();

            return services;
        }
    }
}
