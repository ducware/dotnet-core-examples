using GraphQL_Example.Data;
using GraphQL_Example.Data.Entities;

namespace GraphQL_Example.GraphQL.Interfaces
{
    public interface IMutation
    {
        Task<Cake> SaveCakeAsync(ApplicationDbContext context, Cake cake);
        Task<Cake> UpdateCakeAsync(ApplicationDbContext context, Cake cake);
        Task<string> DeleteCakeAsync(ApplicationDbContext context, int id);
    }
}
