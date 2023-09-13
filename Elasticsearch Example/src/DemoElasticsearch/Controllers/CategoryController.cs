using AutoMapper;
using DemoElasticsearch.Core.Interfaces;
using DemoElasticsearch.Core.Models;
using DemoElasticsearch.Domain.Const;
using Microsoft.AspNetCore.Mvc;

namespace DemoElasticsearch.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ILogger<CategoryController> _logger;
        public CategoryController(IElasticSearchService elasticsearchService, ILogger<CategoryController> logger, IMapper mapper) 
            : base(elasticsearchService, mapper)
        { 
            _logger = logger;
        }

        [HttpPost("send-document")]
        public async Task<IActionResult> SendDocumentToIndexAsync(Category document)
        {
            _elasticsearchService.SendDocumentToIndex(ElasticSearchConst.Category, document);
            _logger.LogInformation("Add Document into Index: categories - ", DateTime.UtcNow);
            return Ok(document);
        }

        [HttpGet("view-document")]
        public async Task<IActionResult> ViewDocumentAsync(string keyword, int size = 10)
        {
            var res = await _elasticsearchService.GetDocumentFromIndex<Category>(ElasticSearchConst.Category, keyword, size);
            if (res.Any())
            {
                _logger.LogInformation("Get Document From Index: categories - ", DateTime.UtcNow);
                return Ok(res);
            }
            return BadRequest("Không tìm kiếm được giá trị phù hợp");
        }

        [HttpDelete("delete-document")]
        public async Task<IActionResult> DeleteDocumentByIdAsync(int id)
        {
            var isExist = await _elasticsearchService.IsExistDocument(ElasticSearchConst.Category, id);
            if (!isExist)
            {
                return NotFound("Không tồn tại document trong index");
            }
            _elasticsearchService.DeleteDocumentById<BaseModel>(ElasticSearchConst.Category, id);
            _logger.LogInformation("Delete Document from Index: categories - ", DateTime.UtcNow);
            return Ok("Đã xóa index thành công");
        }
    }
}
