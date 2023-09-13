using DapperExample.Models;
using DapperExample.Repositories.Common;

namespace DapperExample.Repositories.Fruits
{
    public interface IFruitRepository : IGenericRepository<Fruit>
    {
    }
}
