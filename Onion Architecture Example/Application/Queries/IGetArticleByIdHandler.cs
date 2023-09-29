namespace Application.Queries
{
    public interface IGetArticleByIdHandler
    {
        Task<ArticleResponse?> Handle(Guid id);
    }
}
