using DapperExample.Models;
using DapperExample.Services.Fruits;
using Microsoft.AspNetCore.Mvc;

namespace DapperExample.Controllers
{
    [ApiController]
    [Route("v1/fruits")]
    public class FruitsController : ControllerBase
    {
        private readonly IFruitServices _fruitServices;
        public FruitsController(IFruitServices fruitServices)
        {
            _fruitServices = fruitServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetListFruitsAsync()
        {
            try
            {
                var fruits = await _fruitServices.GetListFruitsAsync();
                return Ok(fruits);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetFruitByIdAsync([FromRoute] int id)
        {
            try
            {
                var fruit = await _fruitServices.GetFruitByIdAsync(id);
                return Ok(fruit);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateFruitAsync(Fruit fruitData)
        {
            try
            {
                var fruit = await _fruitServices.CreateFruit(fruitData);
                if (!fruit)
                {
                    return BadRequest("Error while create");
                }
                return Ok(fruitData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
