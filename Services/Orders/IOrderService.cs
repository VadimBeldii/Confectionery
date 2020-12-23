using System;
using System.Collections.Generic;
using System.Text;

namespace Confectionery.BLL.Services
{
    public interface IOrderService
    {
        ICollection<DTOs.OrderDTO> GetOrders();
        ICollection<DTOs.OrderItemDTO> GetOrderedProducts(); 
        void AddOrder(DTOs.OrderDTO order);
        void Execute(DTOs.OrderDTO order);
    }
}
