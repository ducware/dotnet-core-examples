using Domain.Entities.Animal;

namespace Application.Queries.Animals
{
    public interface IAnimalServices
    {
        Task<IEnumerable<Animal>> GetAnimalsAsync();
    }
}
