using Application.Queries;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;

namespace Persistence.Queries
{
    public class GetArticleByIdQueryHandler : IGetArticleByIdHandler
    {
        private readonly ApplicationDbContext _context;

        public GetArticleByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ArticleResponse?> Handle(Guid id)
        {
            var articleResponse = await _context
                .Articles
                .AsNoTracking()
                .Where(a => a.Id == id)
                .Select(a => new ArticleResponse
                {
                    Id = a.Id,
                    Title = a.Title,
                    Content = a.Content,
                    Tags = a.Tags,
                    Created = a.Created,
                    Puslished = a.Puslished
                }).FirstOrDefaultAsync();

            return articleResponse;
        }
    }
}
