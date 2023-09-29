using Newtonsoft.Json;

namespace Hangfire_with_Twitter.Models
{
    public class PostScheduledTweetRequestDto
    {
        [JsonProperty("text")]
        public string Text { get; set; } = string.Empty;
        public DateTime ScheduleFor { get; set; }
    }
}
