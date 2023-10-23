using Hehehe.Data;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Hehehe
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Database"));
            });

            return services;
        }
    }
}
