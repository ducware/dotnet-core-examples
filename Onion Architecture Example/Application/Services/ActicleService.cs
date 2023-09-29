using Domain.Entities;
using Domain.Repositories;

namespace Application.Services
{
    public sealed class ActicleService
    {
        private readonly IArticleRepository _articleRepository;

        public ActicleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<Guid> CreateAsync(string title, string content, List<string> tags)
        {
            var article = new Article
            {
                Id = Guid.NewGuid(),
                Title = title,
                Content = content,
                Tags = tags,
                Created = DateTime.Now
            };

            var articleId = await _articleRepository.InsertAsync(article);

            return articleId;
        }

        public async Task PublishAsync(Guid id)
        {
            var article = await _articleRepository.GetByIdAsync(id);

            if (article is null)
            {
                throw new ApplicationException("Article not found");
            }

            article.Puslished = DateTime.Now;

            await _articleRepository.UpdateAsync(article);
        }
    }
}
