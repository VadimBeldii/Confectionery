using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

using Confectionery.DAL.EF;
using Confectionery.DAL.EF.Entities;

namespace Confectionery.DAL.Repositories
{
    class OrderRepository : IOrderRepository
    {
        private readonly DbSet<Order> orders;
        private readonly DbSet<OrderItem> orderItems;
        private readonly DbContext context;

        public OrderRepository(ConfectioneryDbContext context)
        {
            orders = context.Orders;
            orderItems = context.OrderItems;
            this.context = context;
        }

        public ICollection<Order> GetOrders()
        {
            return orders.Include(o => o.orderItems).ToList();
        }

        public void RemoveOrder(Order order)
        {
            var o = orders.FirstOrDefault(o => o.Id == order.Id);
            if (o != null)
            {
                orders.Remove(o);
            }
        }

        public void AddOrder(Order order)
        {
            orders.Add(order);
            context.SaveChanges();
        }
    }
}
