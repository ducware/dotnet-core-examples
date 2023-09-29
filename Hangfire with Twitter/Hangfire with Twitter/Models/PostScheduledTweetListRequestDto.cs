namespace Hangfire_with_Twitter.Models
{
    public class PostScheduledTweetListRequestDto
    {
        public List<PostScheduledTweetRequestDto> Tweets { get; set; } = new List<PostScheduledTweetRequestDto>();
    }
}
