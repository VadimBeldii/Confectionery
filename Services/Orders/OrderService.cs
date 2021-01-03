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
        private DAL.IUnitOfWork unitOfWork;
        private IMapper mapper;
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
            foreach(var item in order.OrderItems)
            {
                if (unitOfWork.Products.GetProduct(item.Id).Count < item.Count)
                {
                    return false;
                }
            }
            unitOfWork.Orders.AddOrder(mapper.Map<Order>(order), mapper.Map<ICollection<OrderItem>>(order.OrderItems));
            SaveStatistics(order);
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
            return mapper.Map<ICollection<OrderDTO>>(unitOfWork.Orders.GetOrders());
        }
    }
}
