using AutoMapper;
using DemoElasticsearch.Core.Interfaces;
using DemoElasticsearch.Core.Models;
using DemoElasticsearch.Core.ViewModels;
using DemoElasticsearch.Domain.Const;
using Microsoft.AspNetCore.Mvc;

namespace DemoElasticsearch.Controllers
{
    public class ProductController : BaseController
    {
        private readonly ILogger<ProductController> _logger;
        public ProductController(IElasticSearchService elasticsearchService, ILogger<ProductController> logger, IMapper mapper) 
            : base(elasticsearchService, mapper)
        { 
            _logger = logger;
        }

        [HttpPost("send-document")]
        public async Task<IActionResult> SendDocumentToIndexAsync(Product document)
        {
            _elasticsearchService.SendDocumentToIndex(ElasticSearchConst.Product, document);
            _logger.LogInformation("Add Document into Index: products - ", DateTime.UtcNow);
            return Ok(document);
        }

        [HttpGet("view-document")]
        public async Task<IActionResult> ViewDocumentAsync(string keyword, int size = 10)
        {
            var products = await _elasticsearchService.GetDocumentFromIndex<Product>(ElasticSearchConst.Product, keyword, size);
            if (products.Any())
            {
                _logger.LogInformation("Get Document From Index: products - ", DateTime.UtcNow);
                var res = _mapper.Map<List<ProductVM>>(products);
                return Ok(res);
            }
            return BadRequest("Không tìm kiếm được giá trị phù hợp");
        }

        [HttpDelete("delete-document")]
        public async Task<IActionResult> DeleteDocumentByIdAsync(int id)
        {
            var isExist = await _elasticsearchService.IsExistDocument(ElasticSearchConst.Product, id);
            if (!isExist)
            {
                return NotFound("Không tồn tại document trong index");
            }
            _elasticsearchService.DeleteDocumentById<BaseModel>(ElasticSearchConst.Product, id);
            _logger.LogInformation("Delete Document from Index: products - ", DateTime.UtcNow);
            return Ok("Đã xóa index thành công");
        }
    }
}
