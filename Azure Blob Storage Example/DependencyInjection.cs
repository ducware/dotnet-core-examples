using Azure.Blob.Storage.Configurations;
using Azure.Blob.Storage.Services;
using Azure.Storage.Blobs;

namespace Azure.Blob.Storage
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAzureBlobStorage(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AzureBlobStorageConfig>(configuration.GetSection(nameof(AzureBlobStorageConfig)));

            var azureBlobStorageConfig = configuration.GetSection(nameof(AzureBlobStorageConfig)).Get<AzureBlobStorageConfig>();
            azureBlobStorageConfig ??= new AzureBlobStorageConfig();
            services.AddSingleton(azureBlobStorageConfig);

            services.AddScoped(_ =>
            {
                return new BlobServiceClient(azureBlobStorageConfig.ConnectionStrings);
            });

            services.AddScoped<IFileService, FileService>();

            return services;
        }
    }
}
