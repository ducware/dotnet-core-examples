using GraphQL_Example.Data;
using GraphQL_Example.Data.Entities;
using GraphQL_Example.GraphQL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_Example.GraphQL.Types
{
    public class Query : IQuery
    {
        public async Task<List<Cake>> AllCakeAsync([Service] ApplicationDbContext context)
        {
            return await context.Cakes.ToListAsync();
        }
    }
}
