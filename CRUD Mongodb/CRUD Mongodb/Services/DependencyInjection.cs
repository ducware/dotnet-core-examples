using CRUD_Mongodb.Settings;
using MongoDB.Driver;

namespace CRUD_Mongodb.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongodbSettings>(configuration.GetSection("MongodbSettings"));

            services.AddScoped<IMongodbService, MongodbService >();

            return services;
        }
    }
}
