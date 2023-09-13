namespace DemoElasticsearch.Core.Models
{
    public class Category : BaseModel
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public bool IsDiscounted { get; set; }
    }
}
