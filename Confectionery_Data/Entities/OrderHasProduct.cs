using System;
using System.Collections.Generic;

#nullable disable

namespace Confectionery_EF
{
    public partial class OrderHasProduct
    {
        public int OrderId { get; set; }
        public int? ProductId { get; set; }
        public int Count { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
