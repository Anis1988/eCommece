using API.Dtos;
using API.Entities;
using AutoMapper;

namespace API.Helper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Product,ProductDto>()
                .ForMember(des => des.ProductBrand,opt => opt.MapFrom( src => src.ProductBrand.Name))
                .ForMember(des => des.ProductType,opt => opt.MapFrom( src => src.ProductType.Name));
        }
    }
}
