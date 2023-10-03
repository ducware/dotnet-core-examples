using Application.Commands.Animals.Create;
using AutoMapper;
using Domain.Entities.Animal;

namespace Application.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateAnimalCommand, Animal>();
        }
    }
}