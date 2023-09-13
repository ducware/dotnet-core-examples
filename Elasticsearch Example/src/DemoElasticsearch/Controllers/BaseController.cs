using AutoMapper;
using DemoElasticsearch.Core.Interfaces;
using DemoElasticsearch.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoElasticsearch.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        protected readonly IElasticSearchService _elasticsearchService;
        protected readonly IMapper _mapper;

        public BaseController(IElasticSearchService elasticsearchService, IMapper mapper)
        {
            _elasticsearchService = elasticsearchService;
            _mapper = mapper;
        }
    }
}
