﻿using Application.Commands.Animals.Create;
using Application.Queries.Animals.GetAnimals;
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
        /// GET api/animals: Danh sách động vật.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAnimalsAsync()
        {
            var res = await _mediator.Send(new GetAnimalsQuery());
            return Ok(res);
        }
    }
}
