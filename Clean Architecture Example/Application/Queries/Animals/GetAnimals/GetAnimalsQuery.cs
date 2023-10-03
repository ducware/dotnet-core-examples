using Domain.Common.Queries;
using Domain.Entities.Animal;

namespace Application.Queries.Animals.GetAnimals
{
    public class GetAnimalsQuery : IQuery<IEnumerable<Animal>>
    {
        public GetAnimalsQuery()
        {
        }
    }
}
