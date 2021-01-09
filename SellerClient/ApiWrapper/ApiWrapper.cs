using Confectionery.BLL.DTOs;

using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;

namespace SellerClient
{
    public class ApiWrapper : IApiWrapper
    {
        private readonly IApiClient apiClient = new ApiClient();
        public ICollection<CategoryDTO> GetCategories()
        {
            var result = apiClient.ProcessHttpGetRequest("getcategories");
            return JsonSerializer.Deserialize<ICollection<CategoryDTO>>(result);
        }
        public ICollection<ProductDTO> GetProducts()
        {
            var result = apiClient.ProcessHttpGetRequest("getproducts"); 
            return JsonSerializer.Deserialize<ICollection<ProductDTO>>(result);
        }
        public ICollection<OrderDTO> GetOrders()
        {
            var result = apiClient.ProcessHttpGetRequest("getorders");
            return JsonSerializer.Deserialize<ICollection<OrderDTO>>(result);
        }
        public void SendOrder(OrderDTO order)
        {
            apiClient.ProcessHttpPostRequest("addorder", JsonSerializer.Serialize(order));
        }
        public void MarkOrderAsExecuted(OrderDTO order)
        {
            apiClient.ProcessHttpPostRequest("executeorder", JsonSerializer.Serialize(order));
        }
    }
}
