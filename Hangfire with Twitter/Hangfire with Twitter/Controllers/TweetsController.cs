using Hangfire;
using Hangfire_with_Twitter.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Tweetinvi;
using Tweetinvi.Models;

namespace Hangfire_with_Twitter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public TweetsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [AutomaticRetry(Attempts =0)]
        public async Task<IActionResult> PostTweet(PostTweetRequestDto newTweet)
        {
            var apiKey = _configuration.GetValue<string>("TweetConfig:ApiKey");
            var apiKeySecret = _configuration.GetValue<string>("TweetConfig:ApiKeySecret");
            var accessToken = _configuration.GetValue<string>("TweetConfig:AccessToken");
            var accessTokenSecret = _configuration.GetValue<string>("TweetConfig:AccessTokenSecret");
            var client = new TwitterClient(apiKey, apiKeySecret, accessToken, accessTokenSecret);

            var result = await client.Execute.AdvanceRequestAsync(
                BuildTwitterRequest(newTweet, client, _configuration));

            return Ok(result.Content);
        }

        [HttpPost("schedule")]
        public IActionResult ScheduleTweet(PostScheduledTweetRequestDto newTweet)
        {
            var delay = newTweet.ScheduleFor - DateTime.UtcNow;

            if (delay > TimeSpan.Zero)
            {
                BackgroundJob.Schedule(() => PostTweet(newTweet.Adapt<PostTweetRequestDto>()), delay);
                return Ok("Tweet scheduled!");
            }
            else
            {
                return BadRequest("please enter a valid date and time!");
            }
        }

        [HttpPost("bulk")]
        public IActionResult ScheduleTweets(PostScheduledTweetListRequestDto newTweetList)
        {
            var invalidTweets = new List<PostScheduledTweetRequestDto>();
            int scheduleCount = 0;

            foreach (var tweet in newTweetList.Tweets)
            {
                TimeSpan delay = tweet.ScheduleFor - DateTime.UtcNow;

                if (delay <= TimeSpan.Zero)
                {
                    invalidTweets.Add(tweet);
                    continue;
                }

                BackgroundJob.Schedule(() => PostTweet(tweet.Adapt<PostTweetRequestDto>()), delay);
                scheduleCount++;
            }

            string message;

            if (invalidTweets.Any())
            {
                message = $@"{scheduleCount} tweets schedule successfully ✅
                            {invalidTweets.Count} tweets had invalid dates and were not scheduled ❌";
            }
            else
            {
                message = $"All {scheduleCount} tweets scheduled successfully ✅";
            }

            return Ok(message);
            
        }

        private static Action<ITwitterRequest> BuildTwitterRequest(
            PostTweetRequestDto newTweet,
            TwitterClient client,
            IConfiguration configuration)
        {
            return (ITwitterRequest request) =>
            {
                var jsonBody = client.Json.Serialize(newTweet);
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                request.Query.Url = configuration.GetValue<string>("TwitterEnpoints:PostTweet");
                request.Query.HttpMethod = Tweetinvi.Models.HttpMethod.POST;
                request.Query.HttpContent = content;
            };
        }
    }
}
