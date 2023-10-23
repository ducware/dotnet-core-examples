using Hehehe.Data;
using Hehehe.Models;
using Hehehe.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Hehehe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlansController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PlansController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlanAsync(Plan plan)
        {
            if (plan.Expiration == null)
            {
                plan.Expiration = new()
                {
                    ExactMoment = DateTime.Now,
                    MomentType = 1
                };

            }

            _context.Plans.Add(plan);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, "Created");
        }

        [HttpGet]
        public async Task<IActionResult> GetPlans()
        {
            var planDtos = _context.Plans.Select(plan => new PlanDto
            {
                Id = plan.Id,
                PlanName = plan.PlanName,
                ExpirationJson = plan.ExpirationJson
            }).ToList();

            return Ok(planDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlanByIdAysnc(Guid id)
        {
            var plan = _context.Plans.FirstOrDefault(p => p.Id == id);

            if (plan == null)
            {
                return NotFound();
            }

            var expiration = JsonSerializer.Deserialize<Expiration>(plan.ExpirationJson);

            return Ok(expiration.ExactMoment);
        }
    }
}
