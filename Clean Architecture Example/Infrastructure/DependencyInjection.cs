using Domain.Common;
using Domain.Entities.Animal;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(item => item.UseSqlServer(configuration.GetConnectionString("Db")));
            services.AddSingleton<SqlConnectionFactory>();
            //services.AddScoped<IAnimalRepository, AnimalRepository>();

            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes()
                .Where(type => type.IsClass   // chỉ kiểm tra các lớp
                    && !type.IsAbstract  // không kiểm tra các lớp abstract
                    && type.GetInterfaces()  // lay cac interface ma type này kế thừa
                        .Any(i => i.IsGenericType  // kiểm tra xem có interface nào là generic type không
                                && i.GetGenericTypeDefinition() == typeof(IRepository<>)));  // kiểm tra xem có interface nào kế thừa từ IRepository<T> không

            foreach (var type in types)
            {
                foreach (var iface in type.GetInterfaces())
                {
                    services.AddScoped(iface, type); // đăng ký dịch vụ với DI container
                }
            }

            services.AddTransient<ISqlConnectionFactory, SqlConnectionFactory>();

            return services;
        }
    }
}
