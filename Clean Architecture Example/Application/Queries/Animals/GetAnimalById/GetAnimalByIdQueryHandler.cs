using Domain.Common.Consts;
using Domain.Common.Queries;
using Domain.Entities.Animal;
using Domain.Exceptions;

namespace Application.Queries.Animals.GetAnimalById
{
    public class GetAnimalByIdQueryHandler : IQueryHandler<GetAnimalByIdQuery, Animal>
    {
        private readonly IAnimalServices _animalServices;
        public GetAnimalByIdQueryHandler(IAnimalServices animalServices)
        {
            _animalServices = animalServices;
        }

        public async Task<Animal> Handle(GetAnimalByIdQuery request, CancellationToken cancellationToken)
        {
            var animal = await _animalServices.GetAnimalByIdAsync(request.Id)
               ?? throw new BusinessRuleException("animal_id_is_not_existed", MessageConst.AnimalIdIsNotExisted);

            return animal;
        }
    }
}
