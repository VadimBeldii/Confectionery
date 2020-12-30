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
        public void AddOrder(OrderDTO order)
        {
            foreach(var item in order.OrderItems)
            {
                if (order.OrderItems.Count > 1)
                {
                    unitOfWork.Statistics.Add(new Statistics { Product = mapper.Map<Product>(item.Product), Purchased = item.count });
                }
                else
                {
                    unitOfWork.Statistics.Add(new Statistics { Product = mapper.Map<Product>(item.Product), PurchasedSeparately = item.count });
                }
            }
            unitOfWork.Orders.AddOrder(mapper.Map<Order>(order));
        }

        public void Execute(OrderDTO order)
        {
            unitOfWork.Orders.RemoveOrder(mapper.Map<Order>(order));
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
