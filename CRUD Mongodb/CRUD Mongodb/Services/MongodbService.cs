using CRUD_Mongodb.Models;
using CRUD_Mongodb.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CRUD_Mongodb.Services
{
    public class MongodbService : IMongodbService
    {
        private readonly IMongoCollection<Playlist> _playlistCollection;
        public MongodbService(IOptions<MongodbSettings> mongodbSettings)
        {
            MongoClient client = new MongoClient(mongodbSettings.Value.ConnectionStrings);
            IMongoDatabase database = client.GetDatabase(mongodbSettings.Value.DatabaseName);
            _playlistCollection = database.GetCollection<Playlist>(mongodbSettings.Value.CollectionName);
        }

        public async Task AddToPlaylistAsync(string id, string movieId)
        {
            var objectId = new ObjectId(id);
            FilterDefinition<Playlist> filter = Builders<Playlist>.Filter.Eq("_id", objectId);
            UpdateDefinition<Playlist> update = Builders<Playlist>.Update.AddToSet<string>("items", movieId);
            await _playlistCollection.UpdateOneAsync(filter, update);

            return;
        }

        public async Task CreateAsync(Playlist playlist)
        {
            await _playlistCollection.InsertOneAsync(playlist);
            return;
        }

        public async Task DeleteAsync(string id)
        {
            var objectId = new ObjectId(id);
            FilterDefinition<Playlist> filter = Builders<Playlist>.Filter.Eq("_id", objectId);
            await _playlistCollection.DeleteOneAsync(filter);
            return;
        }

        public async Task<IEnumerable<Playlist>> GetAsync()
        {
            return await _playlistCollection.Find(new BsonDocument()).ToListAsync();
        }
    }
}
