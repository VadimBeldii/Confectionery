using System.Collections.Generic;
using System.Threading.Tasks;
using Confectionery.DAL.EF.Entities;

namespace Confectionery.DAL.Repositories
{
    public interface IOrderRepository
    {
        public Task<ICollection<Order>> GetOrders();
        public void AddOrder(Order order);
        public ICollection<OrderItem> GetOrderedProducts();
        public void RemoveOrder(Order o);
    }
}
