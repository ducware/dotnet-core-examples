using Application.Queries;

namespace Api.Enpoints
{
    public static class ArticleEnpoints
    {
        public static void MapArticleEnpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("api/articles/{id}", async (Guid id, IGetArticleByIdHandler handler) =>
            {
                var article = await handler.Handle(id);

                return article is null ? Results.NotFound() : Results.Ok(article);
            });
        }
    }
}
