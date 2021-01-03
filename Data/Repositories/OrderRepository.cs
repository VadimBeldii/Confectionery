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
        private readonly DbContext context;

        public OrderRepository(ConfectioneryDbContext context)
        {
            orders = context.Orders;
            orderItems = context.OrderItems;
            this.context = context;
        }

        public async Task<ICollection<Order>> GetOrders()
        {
            return await orders.ToListAsync();
        }
        public ICollection<OrderItem> GetOrderedProducts()
        {
            var items = new List<OrderItem>();
            foreach(var g in orderItems.GroupBy(o=>o.ProductId))
            {
                items.Add(new OrderItem
                {
                    ProductId = g.Key,
                    Count = g.Sum(o => o.Count)
                });
            }
            return items;
        }
        public void RemoveOrder(Order order)
        {
            //будет странно, если найдется несколько заказов, сделанных в одну и ту же секунду...наверное
            var o = orders.FirstOrDefault(o => o.Time == order.Time);
            orders.Remove(o);
        }

        public void AddOrder(Order order, ICollection<OrderItem> items)
        {
            orders.Add(order);
            context.SaveChanges();
            var orderId = orders.Select(o => o.Id).Max();
            foreach (var item in items)
            {
                item.OrderId = orderId;
                orderItems.Add(item);
            }
        }

        public async Task<ICollection<OrderItem>> GetItems(Order order)
        {
            return await orderItems.Where(o => o.OrderId == order.Id).ToListAsync();
        }
    }
}
