using GraphQL_Example.Data;
using GraphQL_Example.Data.Entities;

namespace GraphQL_Example.GraphQL.Interfaces
{
    public interface IQuery
    {
        Task<List<Cake>> AllCakeAsync(ApplicationDbContext context);
    }
}
