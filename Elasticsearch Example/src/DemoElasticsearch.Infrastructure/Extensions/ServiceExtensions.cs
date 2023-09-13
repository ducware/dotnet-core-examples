using AutoMapper;
using DemoElasticsearch.Core;
using DemoElasticsearch.Core.Interfaces;
using DemoElasticsearch.Domain.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DemoElasticsearch.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddElasticsearch(configuration);
            services.AddScoped<IElasticSearchService, ElasticSearchService>();

            var mapperConfig = new MapperConfiguration(mc => {
                mc.AddProfile(new MapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
