using AutoMapper;
using MinimalAPI.CouponApi.Models;

namespace MinimalAPI.CouponApi.Configs
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Coupon, CreateCouponDto>().ReverseMap();
            CreateMap<Coupon, CouponDto>().ReverseMap();
        }
    }
}
