using AutoMapper;
using DemoElasticsearch.Core.Models;
using DemoElasticsearch.Core.ViewModels;

namespace DemoElasticsearch.Domain.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, ProductVM>()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Id));

            CreateMap<Product, ProductVM>();
        }
    }
}
