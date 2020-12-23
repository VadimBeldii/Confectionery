using System;
using System.Collections.Generic;
using System.Text;

namespace Confectionery.BLL.DTOs
{
    public class OrderDTO
    {
        public IList<OrderItemDTO> OrderItems { get; set; }
        public DateTime Time { get; set; }
    }
}
