using System;
using System.Collections.Generic;

#nullable disable

namespace Confectionery_Data
{
    public partial class Order
    {
        public int Id { get; set; }
        public TimeSpan Time { get; set; }
        public decimal? TotalPrice { get; set; }
    }
}
