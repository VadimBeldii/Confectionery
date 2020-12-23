using System;
using System.Collections.Generic;
using System.Text;

namespace Confectionery.BLL.DTOs
{
    public class CategoryDTO
    {
        public string Name { get; set; }
        public IList<ProductDTO> Products { get; set; }
    }
}
