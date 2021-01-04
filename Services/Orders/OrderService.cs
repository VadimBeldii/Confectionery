using AutoMapper;
using Confectionery.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Confectionery.DAL.EF.Entities;

namespace Confectionery.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly DAL.IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public OrderService(DAL.IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        private void SaveStatistics(OrderDTO order)
        {
            foreach (var item in order.OrderItems)
            {
                if (order.OrderItems.Count > 1)
                {
                    unitOfWork.Statistics.Add(new Statistics { ProductId = item.ProductId, Purchased = item.Count });
                }
                else
                {
                    unitOfWork.Statistics.Add(new Statistics { ProductId = item.ProductId, PurchasedSeparately = item.Count });
                }
            }
        }
        public bool AddOrder(OrderDTO order)
        { 
            //проверка на корректность
            foreach(var item in order.OrderItems)
            {
                var product = unitOfWork.Products.GetProduct(item.ProductId);
                if (product == null || item.Count > product.Count)
                {
                    return false;
                }
            }
            SaveStatistics(order);
            //уменьшаем количество
            foreach(var item in order.OrderItems)
            {
                var product = unitOfWork.Products.GetProduct(item.ProductId);
                unitOfWork.Products.UpdateProduct(item.ProductId, new[] { KeyValuePair.Create<string, object>("Count", product.Count - item.Count) });
            }
            unitOfWork.Orders.AddOrder(mapper.Map<Order>(order), mapper.Map<ICollection<OrderItem>>(order.OrderItems));
            unitOfWork.Save();
            return true;
        }

        public void Execute(OrderDTO order)
        {
            unitOfWork.Orders.RemoveOrder(mapper.Map<Order>(order));
            unitOfWork.Save();
        }

        public ICollection<OrderItemDTO> GetOrderedProducts()
        {
            return mapper.Map<ICollection<OrderItemDTO>>(unitOfWork.Orders.GetOrderedProducts());
        }

        public ICollection<OrderDTO> GetOrders()
        {
            var result = mapper.Map<ICollection<OrderDTO>>(unitOfWork.Orders.GetOrders().Result);
            foreach (var o in result)
            {
                var items = unitOfWork.Orders.GetItems(mapper.Map<Order>(o)).Result;
                o.OrderItems = mapper.Map<IList<OrderItemDTO>>(items);
            }
            return result;
        }
    }
}
