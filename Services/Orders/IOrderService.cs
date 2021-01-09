using System;
using System.Collections.Generic;
using System.Text;

namespace Confectionery.BLL.Services
{
    public interface IOrderService
    {
        ICollection<DTOs.OrderDTO> GetOrders();
        bool AddOrder(DTOs.OrderDTO order);
        void Execute(DTOs.OrderDTO order);
    }
}
