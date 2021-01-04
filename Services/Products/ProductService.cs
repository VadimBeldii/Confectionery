using AutoMapper;
using Confectionery.BLL.DTOs;
using Confectionery.DAL.EF.Entities;
using System.Collections.Generic;

namespace Confectionery.BLL.Services
{
    public class ProductService : IProductService
    {
        private DAL.IUnitOfWork unitOfWork;
        private IMapper mapper;

        public ProductService(DAL.IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public ICollection<CategoryDTO> GetCategories()
        {
            var result =  mapper.Map<ICollection<CategoryDTO>>(unitOfWork.Products.GetCategories().Result);
            foreach (var c in result)
            {
                var products = unitOfWork.Products.GetProducts(mapper.Map<Category>(c)).Result;
                c.Products = mapper.Map<IList<ProductDTO>>(products);
            }
            return result;
        }

        public ICollection<ProductDTO> GetProducts()
        {
            return mapper.Map<ICollection<ProductDTO>>(unitOfWork.Products.GetProducts().Result);
        }
    }
}
