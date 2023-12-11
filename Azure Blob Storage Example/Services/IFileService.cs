using Azure.Blob.Storage.Models;

namespace Azure.Blob.Storage.Services
{
    public interface IFileService
    {
        Task UploadAsync(FileModels fileModel);
        Task<Stream> GetAsync(string fileName);
        Task DeleteAsync(string fileName);
    }
}
