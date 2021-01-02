using System;
using System.Collections.Generic;
using System.Text;

namespace Confectionery.BLL.Services
{
    public interface IProductService
    {
        public ICollection<DTOs.CategoryDTO> GetCategories();
        public ICollection<DTOs.ProductDTO> GetProducts();
    }
}
