using EFCore.Relationships.Models;
using EFCore.Relationships.Models.DTOs.Categories;
using EFCore.Relationships.Repository.Categories;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.Relationships.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateCategoryDto dto)
        {
            var category = new Category
            {
                Name = dto.Name,
                Description = dto.Description,
            };

            await _categoryRepository.AddAsync(category);
            return Ok("Category was added");
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var categories = await _categoryRepository.GetAsync();
            return Ok(categories);
        }
    }
}
