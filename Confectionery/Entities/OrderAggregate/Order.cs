using System;
using System.Collections.Generic;

namespace Confectionery.DAL.EF.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
