using AutoMapper;
using Confectionery.BLL.DTOs;
using Confectionery.DAL.EF.Entities;

namespace Confectionery.BLL.Mapping
{
    public class CategoryDTOMappingProfile : Profile
    {
        public CategoryDTOMappingProfile()
        {
            CreateMap<CategoryDTO, Category>();
            CreateMap<Category, CategoryDTO>();
        }
    }
}
