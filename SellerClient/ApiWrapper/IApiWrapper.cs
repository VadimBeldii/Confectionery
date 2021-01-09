using Confectionery.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SellerClient
{
    public interface IApiWrapper
    {
        public ICollection<CategoryDTO> GetCategories();
        public ICollection<ProductDTO> GetProducts();
        public ICollection<OrderDTO> GetOrders();
        public void SendOrder(OrderDTO order);
        public void MarkOrderAsExecuted(OrderDTO order);
    }
}
