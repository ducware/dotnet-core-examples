using AutoMapper;
using DemoElasticsearch.Core.Interfaces;
using DemoElasticsearch.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoElasticsearch.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ElasticsearchController : BaseController
    {
        private readonly ILogger<ElasticsearchController> _logger;

        public ElasticsearchController(IElasticSearchService elasticsearchService, ILogger<ElasticsearchController> logger,
            IMapper mapper) 
            : base(elasticsearchService, mapper)
        {
            _logger = logger;
        }

        [HttpPost("create-index")]
        public async Task<IActionResult> CreateElasticsearchAsync(string index)
        {
            bool isExist = _elasticsearchService.IsExist(index);
            if (!isExist)
            {
                _elasticsearchService.CreateElasticSearchIndex(index);
                _logger.LogInformation("Create Index - ", DateTime.UtcNow);
                return Ok("Tạo index thành công");
            }
            return BadRequest("Index đã tồn tại");

                
        }

        [HttpDelete("delete-index")]
        public async Task<IActionResult> DeleteElasticsearchAsync(string index)
        {
            bool isExist = _elasticsearchService.IsExist(index);
            if (isExist)
            {
                _elasticsearchService.DeleteElasticSearchIndex(index);
                _logger.LogInformation("Delete Index - ", DateTime.UtcNow);
                return Ok("Đã xóa index thành công");
            }
            return NotFound("Index không tồn tại");
        }

        [HttpPost("send-document")]
        public async Task<IActionResult> SendDocumentToIndexAsync(string index, BaseModel document)
        {
            _elasticsearchService.SendDocumentToIndex(index, document);
            _logger.LogInformation("Send Document into Index - ", DateTime.UtcNow);
            return Ok(document);
        }

        [HttpDelete("delete-document")]
        public async Task<IActionResult> DeleteDocumentByIdAsync(string index, int id)
        {
            var isExist = await _elasticsearchService.IsExistDocument(index, id);
            if (!isExist)
            {
                return NotFound("Không tồn tại document trong index");
            }
            _elasticsearchService.DeleteDocumentById<BaseModel>(index, id);
            _logger.LogInformation("Delete Document from Index - ", DateTime.UtcNow);
            return Ok("Đã xóa index thành công");
        }

        [HttpGet("view-document")]
        public async Task<IActionResult> ViewDocumentAsync(string index, string keyword, int size=10)
        {
            var isExist = _elasticsearchService.IsExist(index);
            if (!isExist)
            {
                return BadRequest("Index không tồn tại");
            }
            var res = await _elasticsearchService.GetDocumentFromIndex<BaseModel>(index, keyword, size);
            if (res.Any())
            {
                _logger.LogInformation("Get Document From Index - ", DateTime.UtcNow);
                return Ok(res);
            }
            return BadRequest("Không tìm kiếm được giá trị phù hợp");
        }

        [HttpGet("view-index-list")]
        public async Task<IActionResult> ViewIndexListAsync()
        {
            var res = await _elasticsearchService.GetIndexList();
            _logger.LogInformation("Get Index List - ", DateTime.UtcNow);
            return Ok(res);
        }
    }
}
