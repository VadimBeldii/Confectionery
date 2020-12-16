using System;
using System.Collections.Generic;

#nullable disable

namespace Confectionery_EF
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public virtual Category Category { get; set; }
    }
}
