using DapperExample.Data;
using DapperExample.Models;
using DapperExample.Repositories.Common;

namespace DapperExample.Repositories.Fruits
{
    public class FruitRepository : GenericRepository<Fruit>, IFruitRepository
    {
        public FruitRepository(AppDbContext context) : base(context)
        {
        }
    }
}
