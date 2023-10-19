using CRUD_Mongodb.Models;

namespace CRUD_Mongodb.Services
{
    public interface IMongodbService
    {
        Task CreateAsync(Playlist playlist);
        Task<IEnumerable<Playlist>> GetAsync();
        Task AddToPlaylistAsync(string id, string movieId);
        Task DeleteAsync(string id);
    }
}
