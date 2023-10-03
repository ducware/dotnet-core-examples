using Domain.Common.Consts;
using Domain.Common.Queries;
using Domain.Entities.Animal;
using Domain.Exceptions;
using Domain.Models;

namespace Application.Commands.Animals.Delete
{
    public class DeleteAnimalCommandHandler : IQueryHandler<DeleteAnimalCommand, ResponseBase>
    {
        private readonly IAnimalRepository _animalRepository;
        public DeleteAnimalCommandHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<ResponseBase> Handle(DeleteAnimalCommand request, CancellationToken cancellationToken)
        {
            var animal = await _animalRepository.GetByIdAsync(request.Id)
                ?? throw new BusinessRuleException("animal_id_is_not_existed", MessageConst.AnimalIdIsNotExisted);

            await _animalRepository.DeleteAsync(animal);
            await _animalRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return new ResponseBase("success", "Xóa động vật thành công!");
        }
    }
}
