using Hangfire;
using Hangfire_RabbitMQ.Data;
using Hangfire_RabbitMQ.RabbitMQ;
using Hangfire_RabbitMQ.Services;
using Microsoft.EntityFrameworkCore;

namespace Hangfire_RabbitMQ.Extensions
{
    public static class DIExtensions
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
);

            //Hangfire
            services.AddHangfire(x => x.UseSqlServerStorage(@"Data Source=.;Initial Catalog=hangfire;Integrated Security=True;Pooling=False;Trusted_Connection=True;TrustServerCertificate=True;"));
            services.AddHangfireServer();

            // DI Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRabitMQProducer, RabitMQProducer>();
            services.AddScoped<IRabbitMQConsumer, RabbitMQConsumer>();

            return services;
        }
    }
}
