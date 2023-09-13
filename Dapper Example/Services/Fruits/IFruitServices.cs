using DapperExample.Models;

namespace DapperExample.Services.Fruits
{
    public interface IFruitServices
    {
        Task<bool> CreateFruit(Fruit fruit);

        Task<IEnumerable<Fruit>> GetAllFruits();

        Task<Fruit> GetFruitById(int id);
        Task<Fruit> GetFruitByIdAsync(int id);

        Task<bool> UpdateFruit(Fruit fruit);

        Task<bool> DeleteFruit(int id);
        Task<IEnumerable<Fruit>> GetListFruitsAsync();
    }
}
