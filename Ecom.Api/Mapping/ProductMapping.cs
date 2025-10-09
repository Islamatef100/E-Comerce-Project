using AutoMapper;
using Ecom.Core.DTO;
using Ecom.Core.Entities.Product;

namespace Ecom.Api.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, ProductDTO>().ForMember(conf => conf.CategoryName, src => src.MapFrom(x => x.Category.Name)).ReverseMap();

            CreateMap<AddProductDTO, Product>()
                .ForMember(x => x.Photos, Z => Z.Ignore())
                .ReverseMap();
            CreateMap<UpdateProductDTO, Product>()
              .ForMember(x => x.Photos, Z => Z.Ignore())
              .ReverseMap();
        }
    }
}
