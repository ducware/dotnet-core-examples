using Domain.Common.Commands;
using Domain.Common.Consts;
using Domain.Entities.Animal;
using Domain.Exceptions;
using Domain.Models;

namespace Application.Commands.Animals.Update
{
    public class UpdateAnimalCommandHandler : ICommandHandler<UpdateAnimalCommand, ResponseBase>
    {
        private readonly IAnimalRepository _animalRepository;
        public UpdateAnimalCommandHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<ResponseBase> Handle(UpdateAnimalCommand request, CancellationToken cancellationToken)
        {
            var animal = await _animalRepository.GetByIdAsync(request.Id)
                ?? throw new BusinessRuleException("animal_id_is_not_existed", MessageConst.AnimalIdIsNotExisted);

            animal.UpdateAnimal(request.Name, request.Description, request.Age, request.IsBird);

            await _animalRepository.UpdateAsync(animal);

            await _animalRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return new ResponseBase("success", "Cập nhật động vật thành công");
        }
    }
}
