namespace LogToElasticsearch.Configurations
{
    public class ElasticsearchConfiguration
    {
        public const string Section = "ElasticsearchConfiguration";
        public string Uri { get; init; }
        public string Username { get; init; }
        public string Password { get; init; }
    }
}
