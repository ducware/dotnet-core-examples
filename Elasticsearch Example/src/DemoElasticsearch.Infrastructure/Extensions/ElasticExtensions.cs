//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Configuration;
//using Nest;
//using DemoElasticsearch.Core.Models;

//namespace DemoElasticsearch.Infrastructure.Extensions
//{
//    public static class ElasticExtensions
//    {
//        public static void AddElasticsearch(
//            this IServiceCollection services, IConfiguration configuration)
//        {
//            var url = configuration["ELKConfiguration:url"];
//            var defaultIndex = configuration["ELKConfiguration:index"];

//            var settings = new ConnectionSettings(new Uri(url))/*.BasicAuthentication(userName, pass)*/
//                .PrettyJson()
//                .DefaultIndex(defaultIndex);

//            AddDefaultMappings(settings);

//            var client = new ElasticClient(settings);

//            services.AddSingleton<IElasticClient>(client);

//            CreateIndex(client, defaultIndex);
//        }

//        private static void AddDefaultMappings(ConnectionSettings settings)
//        {
//            settings
//                .DefaultMappingFor<Product>(m => m

//                 .Ignore(p => p.Price)
//                .Ignore(p => p.Measurement)
//                );
//        }

//        private static void CreateIndex(IElasticClient client, string indexName)
//        {
//            var createIndexResponse = client.Indices.Create(indexName,
//                index => index.Map<Product>(x => x.AutoMap())
//            );
//        }
//    }
//}
