using Domain.Common.Queries;
using Domain.Entities.Animal;

namespace Application.Queries.Animals.GetAnimals
{
    public class GetAnimalsQueryHandler : IQueryHandler<GetAnimalsQuery, IEnumerable<Animal>>
    {
        private readonly IAnimalServices _animalServices;
        public GetAnimalsQueryHandler(IAnimalServices animalServices)
        {
            _animalServices = animalServices;
        }

        public async Task<IEnumerable<Animal>> Handle(GetAnimalsQuery request, CancellationToken cancellationToken)
        {
            var animals = await _animalServices.GetAnimalsAsync();
            return animals;
        }
    }
}
