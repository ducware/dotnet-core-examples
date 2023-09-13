using AutoMapper;
using DemoElasticsearch.Core.Interfaces;
using DemoElasticsearch.Core.Models;
using DemoElasticsearch.Domain.Const;
using Microsoft.AspNetCore.Mvc;

namespace DemoElasticsearch.Controllers
{
    public class UserController : BaseController
    {
        private readonly ILogger<UserController> _logger;
        public UserController(IElasticSearchService elasticsearchService, ILogger<UserController> logger,
            IMapper mapper) 
            : base(elasticsearchService, mapper)
        { 
            _logger = logger;
        }

        [HttpPost("send-document")]
        public async Task<IActionResult> SendDocumentToIndexAsync(User document)
        {
            _elasticsearchService.SendDocumentToIndex(ElasticSearchConst.User, document);
            _logger.LogInformation("Add Document into Index: users - ", DateTime.UtcNow);
            return Ok(document);
        }

        [HttpGet("view-document")]
        public async Task<IActionResult> ViewDocumentAsync(string keyword, int size = 10)
        {
            var res = await _elasticsearchService.GetDocumentFromIndex<User>(ElasticSearchConst.User, keyword, size);
            if (res.Any())
            {
                _logger.LogInformation("Get Document From Index: users - ", DateTime.UtcNow);
                return Ok(res);
            }
            return BadRequest("Không tìm kiếm được giá trị phù hợp");
        }

        [HttpDelete("delete-document")]
        public async Task<IActionResult> DeleteDocumentByIdAsync(int id)
        {
            var isExist = await _elasticsearchService.IsExistDocument(ElasticSearchConst.User, id);
            if (!isExist)
            {
                return NotFound("Không tồn tại document trong index");
            }
            _elasticsearchService.DeleteDocumentById<BaseModel>(ElasticSearchConst.User, id);
            _logger.LogInformation("Delete Document from Index: users - ", DateTime.UtcNow);
            return Ok("Đã xóa index thành công");
        }
    }
}
