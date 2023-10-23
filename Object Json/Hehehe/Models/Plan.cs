using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Hehehe.Models
{
    public class Plan
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; } = Guid.NewGuid();
        [JsonPropertyName("plan_name")]
        public string? PlanName { get; set; }
        [JsonPropertyName("expiration")]
        [NotMapped]
        public Expiration? Expiration { get; set; } = new();
        [JsonPropertyName("expiration_json")]
        public string ExpirationJson
        {
            get => JsonSerializer.Serialize(Expiration);
            set => Expiration = JsonSerializer.Deserialize<Expiration>(value);
        }
    }
}
