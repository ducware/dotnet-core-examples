using System.Text.Json.Serialization;

namespace Date.API.Models
{
    public class DayInMonthDto
    {
        [JsonPropertyName("month")]
        public int Month { get; set; }
        [JsonPropertyName("year")]
        public int Year { get; set; }
    }
}
