using System;
using System.Collections.Generic;
using System.Text;

namespace Confectionery.BLL.Services
{
    public interface IProductService
    {
        public ICollection<DTOs.ProductDTO> GetProducts();
        public ICollection<DTOs.CategoryDTO> GetCategories();
    }
}
