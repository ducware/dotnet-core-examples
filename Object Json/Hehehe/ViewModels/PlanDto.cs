using Hehehe.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Hehehe.ViewModel
{
    public class PlanDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("plan_name")]
        public string? PlanName { get; set; }
        [JsonPropertyName("expiration_json")]
        public string? ExpirationJson { get; set; }
    }
}
