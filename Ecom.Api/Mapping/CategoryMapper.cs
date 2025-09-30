using AutoMapper;
using Ecom.Core.DTO;
using Ecom.Core.Entities.Product;

namespace Ecom.Api.Mapping
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<CategoryDTO,Category>().ReverseMap();
            CreateMap<UpdateCategoryDTO, Category>().ReverseMap();

        }
    }
}
