using EFCore.Relationships.Models;
using EFCore.Relationships.Models.DTOs.Products;
using EFCore.Relationships.Repository.Categories;
using EFCore.Relationships.Repository.Products;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.Relationships.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductsController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var products = await _productRepository.GetIncludeOrderAsync();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateProductDto dto)
        {
            if (await _categoryRepository.GetByIdAsync(dto.CategoryId) == null)
            {
                return NotFound("category_not_exists");
            }

            var product = new Product
            {
                Price = dto.Price,
                Name = dto.Name,
                CategoryId = dto.CategoryId
            };

            await _productRepository.AddAsync(product);
            return Ok("Product was added");
        }
    }
}
