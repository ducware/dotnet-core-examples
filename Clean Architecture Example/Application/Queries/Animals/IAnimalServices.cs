using Application.Queries.Animals.GetAnimalById;
using Domain.Entities.Animal;

namespace Application.Queries.Animals
{
    public interface IAnimalServices
    {
        Task<IEnumerable<Animal>> GetAnimalsAsync();
        Task<Animal> GetAnimalByIdAsync(int id);
    }
}
