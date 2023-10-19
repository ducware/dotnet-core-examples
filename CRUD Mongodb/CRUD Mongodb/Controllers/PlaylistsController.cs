using CRUD_Mongodb.Models;
using CRUD_Mongodb.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Mongodb.Controllers
{
    [Route("api/playlists")]
    [ApiController]
    public class PlaylistsController : ControllerBase
    {
        private readonly IMongodbService _mongodbService;
        public PlaylistsController(IMongodbService mongodbService)
        {
            _mongodbService = mongodbService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlaylistsAsync()
        {
            var playlists = await _mongodbService.GetAsync();
            return Ok(playlists);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlaylistAsync([FromBody] Playlist playlist)
        {
            await _mongodbService.CreateAsync(playlist);
            return StatusCode(StatusCodes.Status201Created, playlist);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AddToPlaylistAsync(string id, [FromBody] string movieId)
        {
            await _mongodbService.AddToPlaylistAsync(id, movieId);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> RemovePlaylistAsync(string id)
        {
            await _mongodbService.DeleteAsync(id);
            return NoContent();
        }
    }
}
