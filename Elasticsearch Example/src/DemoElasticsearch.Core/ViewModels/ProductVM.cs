using DemoElasticsearch.Core.Models;

namespace DemoElasticsearch.Core.ViewModels
{
    public class ProductVM
    {
        public ProductVM()
        {
          Product = new Product();
        }
        public Product Product { get; set; }
        public int CategoryId { get; set; }
    }
}
