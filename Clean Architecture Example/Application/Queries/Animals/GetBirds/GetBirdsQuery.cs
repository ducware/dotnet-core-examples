using Domain.Common.Queries;
using Domain.Entities.Animal;

namespace Application.Queries.Animals.GetBirds
{
    public class GetBirdsQuery : IQuery<IEnumerable<Animal>>
    {
    }
}
