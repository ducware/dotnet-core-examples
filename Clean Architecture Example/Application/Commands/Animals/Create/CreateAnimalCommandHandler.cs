using AutoMapper;
using Domain.Common.Commands;
using Domain.Entities.Animal;
using Domain.Models;

namespace Application.Commands.Animals.Create
{
    public class CreateAnimalCommandHandler : ICommandHandler<CreateAnimalCommand, ResponseBase>
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IMapper _mapper;
        public CreateAnimalCommandHandler(IAnimalRepository animalRepository, IMapper mapper)
        {
            _animalRepository = animalRepository;
            _mapper = mapper;
        }

        public async Task<ResponseBase> Handle(CreateAnimalCommand request, CancellationToken cancellationToken)
        {
            var animal = _mapper.Map<Animal>(request);

            await _animalRepository.AddAsync(animal);
            await _animalRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return new ResponseBase("success", "Thêm mới động vật thành công");
        }
    }
}
