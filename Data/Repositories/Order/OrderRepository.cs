using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

using Confectionery.DAL.EF;
using Confectionery.DAL.EF.Entities;
using System.Threading.Tasks;

namespace Confectionery.DAL.Repositories
{
    class OrderRepository : IOrderRepository
    {
        private readonly DbSet<Order> orders;
        private readonly DbSet<OrderItem> orderItems;

        public OrderRepository(ConfectioneryDbContext context)
        {
            orders = context.Orders;
            orderItems = context.OrderItems;
        }

        public async Task<ICollection<Order>> GetOrders()
        {
            return await orders.ToListAsync<Order>();
        }
        public ICollection<OrderItem> GetOrderedProducts()
        {
            var items = new List<OrderItem>();
            foreach(var g in orderItems.GroupBy(o=>o.Product))
            {
                items.Add(new OrderItem
                {
                    Product = g.Key,
                    Count = g.Sum(o => o.Count)
                });
            }
            return items;
        }
        public void RemoveOrder(Order o)
        {
            orders.Remove(o);
        }

    }
}
