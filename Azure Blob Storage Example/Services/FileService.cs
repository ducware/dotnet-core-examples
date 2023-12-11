using Azure.Blob.Storage.Configurations;
using Azure.Blob.Storage.Models;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Options;

namespace Azure.Blob.Storage.Services
{
    public class FileService : IFileService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly AzureBlobStorageConfig _azureBlobStorageConfig;

        public FileService(BlobServiceClient blobServiceClient, IOptions<AzureBlobStorageConfig> azureBlobStorageConfig)
        {
            _blobServiceClient = blobServiceClient;
            _azureBlobStorageConfig = azureBlobStorageConfig.Value;
        }

        public async Task UploadAsync(FileModels fileModel)
        {
            var containerInstance = _blobServiceClient.GetBlobContainerClient(_azureBlobStorageConfig.BlobContainerClient);
            var blobInstance = containerInstance.GetBlobClient(fileModel.ImageFile.FileName);
            await blobInstance.UploadAsync(fileModel.ImageFile.OpenReadStream());
        }

        public async Task<Stream> GetAsync(string fileName)
        {
            var containerInstance = _blobServiceClient.GetBlobContainerClient(_azureBlobStorageConfig.BlobContainerClient);
            var blobInstance = containerInstance.GetBlobClient(fileName);
            var downloadContent = await blobInstance.DownloadStreamingAsync();
            return downloadContent.Value.Content;
        }

        public async Task DeleteAsync(string fileName)
        {
            var containerInstance = _blobServiceClient.GetBlobContainerClient(_azureBlobStorageConfig.BlobContainerClient);
            var blobInstance = containerInstance.GetBlobClient(fileName);
            await blobInstance.DeleteIfExistsAsync();
        }
    }
}
