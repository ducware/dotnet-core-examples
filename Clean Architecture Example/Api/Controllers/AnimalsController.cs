using Application.Commands.Animals.Create;
using Application.Commands.Animals.Delete;
using Application.Commands.Animals.Update;
using Application.Queries.Animals.GetAnimalById;
using Application.Queries.Animals.GetAnimals;
using Application.Queries.Animals.GetBirds;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/animals")]
    public class AnimalsController : BaseController
    {
        public AnimalsController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// POST api/animals: Thêm mới động vật.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddMessageUserAsync([FromBody] CreateAnimalCommand model)
        {
            var res = await _mediator.Send(model);
            return Ok(res);
        }
        
        /// <summary>
        /// GET api/animals: Lấy danh sách động vật.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAnimalsAsync()
        {
            var res = await _mediator.Send(new GetAnimalsQuery());
            return Ok(res);
        }

        /// <summary>
        /// GET api/animals: Lấy danh sách động vật theo id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAnimalByIdAsync([FromRoute] int id)
        {
            var res = await _mediator.Send(new GetAnimalByIdQuery(id));
            return Ok(res);
        }

        /// <summary>
        /// GET api/animals/birds: Lấy danh sách động vật là chim.
        /// </summary>
        /// <returns></returns>
        [HttpGet("birds")]
        public async Task<IActionResult> GetBirdsAsync()
        {
            var res = await _mediator.Send(new GetBirdsQuery());
            return Ok(res);
        }

        /// <summary>
        /// PUT api/animals/id: Sửa động vật theo Id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAnimalAsync([FromRoute] int id, [FromBody] UpdateAnimalCommand model)
        {
            model.SetId(id);
            var res = await _mediator.Send(model);
            return Ok(res);
        }

        /// <summary>
        /// DELETE api/animals/id: Xóa động vật theo Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAnimalAsync([FromRoute] int id)
        {
            var res = await _mediator.Send(new DeleteAnimalCommand(id));
            return Ok(res);
        }
    }
}
