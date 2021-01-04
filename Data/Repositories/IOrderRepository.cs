using System.Collections.Generic;
using System.Threading.Tasks;
using Confectionery.DAL.EF.Entities;

namespace Confectionery.DAL.Repositories
{
    public interface IOrderRepository
    {
        public Task<ICollection<Order>> GetOrders();
        public void AddOrder(Order order, ICollection<OrderItem> items);
        public ICollection<OrderItem> GetOrderedProducts();
        public Task<ICollection<OrderItem>> GetItems(Order order);
        public void RemoveOrder(Order o);
    }
}
