using Azure.Blob.Storage.Models;
using Azure.Blob.Storage.Services;
using Microsoft.AspNetCore.Mvc;

namespace Azure.Blob.Storage.Controllers
{
    [Route("v1/files")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FilesController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadAsync([FromForm] FileModels file)
        {
            await _fileService.UploadAsync(file);
            return Ok("Uploaded file");
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAsync(string name)
        {
            var imageFileStream = await _fileService.GetAsync(name);
            string fileType = "jpg";
            if (name.Contains("png"))
            {
                fileType = "png";
            }

            return File(imageFileStream, $"image/{fileType}");
        }

        [HttpGet("download")]
        public async Task<IActionResult> DownloadAsync(string name)
        {
            var imageFileStream = await _fileService.GetAsync(name);
            string fileType = "jpg";
            if (name.Contains("png"))
            {
                fileType = "png";
            }

            return File(imageFileStream, $"image/{fileType}", $"blobfile.{fileType}");
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAsync(string name)
        {
            await _fileService.DeleteAsync(name);
            return Ok("Deleted file");
        }
    }
}
