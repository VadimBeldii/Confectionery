using AutoMapper;
using Confectionery.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

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
            //DEBUG
            var r = unitOfWork.Products.GetCategories().Result;
            var m = mapper.Map<ICollection<CategoryDTO>>(r);
            return m;
        }

        public ICollection<ProductDTO> GetProducts()
        {
            return mapper.Map<ICollection<ProductDTO>>(unitOfWork.Products.GetProducts());
        }
    }
}
