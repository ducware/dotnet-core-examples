namespace Application.Queries
{
    public class ArticleResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public List<string> Tags { get; set; } = new();
        public DateTime Created { get; set; }
        public DateTime? Puslished { get; set; }
    }
}
