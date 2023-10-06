using GraphQL_Example.Data;
using GraphQL_Example.GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_Example.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Database"));
            });

            services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>();
                

            return services;
        }
    }
}
