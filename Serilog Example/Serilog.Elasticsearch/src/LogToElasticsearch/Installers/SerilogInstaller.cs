using LogToElasticsearch.Configurations;
using Serilog;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;
using System.Reflection;

namespace LogToElasticsearch.Installers
{
    public class SerilogInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var elasticsearchConfiguration = new ElasticsearchConfiguration();
            configuration.GetSection(nameof(ElasticsearchConfiguration)).Bind(elasticsearchConfiguration);

            services.AddSingleton(elasticsearchConfiguration);

            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var indexFormat = $"{Assembly.GetExecutingAssembly().GetName().Name.ToLower()}-{environment.ToLower().Replace(".", "_")}-{DateTime.UtcNow:yyyy-MM-dd}";

            //Serilog
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithExceptionDetails()
                .WriteTo.Console()
                .WriteTo.Debug()
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(
                    new Uri(elasticsearchConfiguration.Uri))
                {
                    AutoRegisterTemplate = true,
                    IndexFormat = indexFormat,
                    ModifyConnectionSettings = x => x.BasicAuthentication(elasticsearchConfiguration.Username, elasticsearchConfiguration.Password),
                })
                .CreateLogger();
        }
    }
}
