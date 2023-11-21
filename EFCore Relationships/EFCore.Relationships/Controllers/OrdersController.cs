using EFCore.Relationships.Models.DTOs.Products;
using EFCore.Relationships.Models;
using EFCore.Relationships.Repository.Orders;
using Microsoft.AspNetCore.Mvc;
using EFCore.Relationships.Models.DTOs.Orders;
using EFCore.Relationships.Repository.Products;

namespace EFCore.Relationships.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrdersController(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var products = await _orderRepository.GetIncludeProductAsync();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateOrderDto dto)
        {

            var order = new Order
            {
                Name = dto.Name,
            };

            await _orderRepository.AddAsync(order);
            return Ok("Order was added");
        }

        [HttpPost("order-product")]
        public async Task<IActionResult> Create(CreateOrderProductDto dto)
        {
            var product = await _productRepository.GetByIdAsync(dto.ProductId);
            if (product == null)
            {
                return NotFound("Product Id is not exists");
            }

            var order = await _orderRepository.GetByIdIncludeProductAsync(dto.OrderId);

            if (order == null)
            {
                return NotFound("Order Id is not exists");
            }

            order.Products.Add(product);

            await _orderRepository.UnitOfWork.SaveChangesAsync();

            return Ok($"Product {product.Name} is add to Order {order.Name} successfully");
        }
    }
}
