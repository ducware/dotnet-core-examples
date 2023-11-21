using System.Text.Json.Serialization;

namespace EFCore.Relationships.Models
{
    public class Account // Acount(UserId) (1:1) User({Account*})
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        [JsonIgnore]
        public User User { get; set; }
        [JsonPropertyName("user_id")]
        public int UserId { get; set; }
    }
}
