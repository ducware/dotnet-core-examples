using GraphQL_Example.Data;
using GraphQL_Example.Data.Entities;
using GraphQL_Example.GraphQL.Interfaces;

namespace GraphQL_Example.GraphQL.Types
{
    public class Mutation : IMutation
    {
        public async Task<string> DeleteCakeAsync([Service] ApplicationDbContext context, int id)
        {
            var cake = await context.Cakes.FindAsync(id);
            if (cake == null)
            {
                return "invalid operation!";
            }

            context.Cakes.Remove(cake);
            await context.SaveChangesAsync();
            return "Deleted!";
        }

        public async Task<Cake> SaveCakeAsync([Service] ApplicationDbContext context, Cake cake)
        {
            await context.Cakes.AddAsync(cake);
            await context.SaveChangesAsync();

            return cake;
        }

        public async Task<Cake> UpdateCakeAsync([Service] ApplicationDbContext context, Cake cake)
        {
            context.Cakes.Update(cake);
            await context.SaveChangesAsync();
            return cake;
        }
    }
}
