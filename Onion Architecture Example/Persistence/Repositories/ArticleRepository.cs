using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;

namespace Persistence.Repositories
{
    public sealed class ArticleRepository : IArticleRepository
    {
        private readonly ApplicationDbContext _context;

        public ArticleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Article?> GetByIdAsync(Guid id)
        {
            var article = await _context.Articles.FirstOrDefaultAsync(a => a.Id == id);
            return article;
        }

        public async Task<Guid> InsertAsync(Article article)
        {
            _context.Articles.Add(article);
            
            await _context.SaveChangesAsync();

            return article.Id;
        }

        public async Task UpdateAsync(Article article)
        {
            _context.Articles.Update(article);
            await _context.SaveChangesAsync();
        }
    }
}
