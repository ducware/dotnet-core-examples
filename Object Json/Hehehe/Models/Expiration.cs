using System.Text.Json.Serialization;

namespace Hehehe.Models
{
    public class Expiration
    {
        [JsonPropertyName("moment_type")]
        public int MomentType { get; set; } = 3;
        [JsonPropertyName("exact_moment")]

        public DateTime ExactMoment { get; set; } = DateTime.Now;
    }
}
