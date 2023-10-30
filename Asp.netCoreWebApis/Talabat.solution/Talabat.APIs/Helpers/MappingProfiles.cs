using AutoMapper;
using Talabat.APIs.Dtos;
using Talabat.Core.Entites;

namespace Talabat.APIs.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles(/*IConfiguration config*/)
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(res => res.Brand, o => o.MapFrom(s => s.Brand.Name))
                .ForMember(res => res.Category, o => o.MapFrom(s => s.Category.Name))
                //.ForMember(res => res.PictureUrl, o => o.MapFrom(s => $"{config["ApiBaseUrl"]}/{s.PictureUrl}"));
                .ForMember(res => res.PictureUrl, o => o.MapFrom<ProductPictureUrlResolver>());
        }
    }
}
