using Domain.Common.Queries;
using Domain.Entities.Animal;

namespace Application.Queries.Animals.GetBirds
{
    public class GetBirdsQueryHandler : IQueryHandler<GetBirdsQuery, IEnumerable<Animal>>
    {
        private readonly IAnimalServices _animalServices;
        public GetBirdsQueryHandler(IAnimalServices animalServices)
        {
            _animalServices = animalServices;
        }

        public async Task<IEnumerable<Animal>> Handle(GetBirdsQuery request, CancellationToken cancellationToken)
        {
            var birds = await _animalServices.GetBirdsAsync();
            return birds;
        }
    }
}
