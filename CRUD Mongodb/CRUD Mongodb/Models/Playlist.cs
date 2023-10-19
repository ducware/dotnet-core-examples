using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace CRUD_Mongodb.Models
{
    public class Playlist
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("id")]
        public string? Id { get; set; }
        [BsonElement("username")]
        public string? Username { get; set; }
        [BsonElement("items")]
        [JsonPropertyName("items")]
        public List<string>? MovieId { get; set; }
    }
}
