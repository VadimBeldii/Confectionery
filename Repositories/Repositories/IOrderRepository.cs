using System;
using System.Collections.Generic;
using Confectionery_EF;

namespace Confectionery_Data.Repositories
{
    public interface IOrderRepository
    {
        ICollection<ICollection<KeyValuePair<Product, uint>>> GetActiveOrders();
        bool 
    }
}

