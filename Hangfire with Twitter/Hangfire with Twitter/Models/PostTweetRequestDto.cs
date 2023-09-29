using Newtonsoft.Json;

namespace Hangfire_with_Twitter.Models
{
    public class PostTweetRequestDto
    {
        [JsonProperty("text")]
        public string Text { get; set; } = string.Empty;
    }
}
