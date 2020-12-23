using AutoMapper;
using Confectionery.BLL.DTOs;
using Confectionery.DAL.EF.Entities;

namespace Confectionery.BLL.Mapping
{
    public class ProductDTOMappingProfile: Profile
    {
        public ProductDTOMappingProfile()
        {
            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>();
        }
    }
}
