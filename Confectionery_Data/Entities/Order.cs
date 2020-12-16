using System;
using System.Collections.Generic;

#nullable disable

namespace Confectionery_EF
{
    public partial class Order
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public decimal? TotalPrice { get; set; }
    }
}
