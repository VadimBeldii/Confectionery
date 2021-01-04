using Confectionery.BLL.DTOs;

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;

namespace SellerClient
{
    public static class ApiWrapper
    {
        private static readonly string host = "http://192.168.0.60:56424/api/seller";

        public static ICollection<CategoryDTO> GetCategories()
        {
            var request = WebRequest.Create($"{host}/getcategories") as HttpWebRequest;
            request.Method = "GET";
            request.ContentType = "application/json";

            var response = request.GetResponse() as HttpWebResponse;

            if (response?.StatusCode != HttpStatusCode.OK)
                return null;

            var streamReader = new StreamReader(response.GetResponseStream());
            var result = streamReader.ReadToEnd();

            return JsonSerializer.Deserialize<ICollection<CategoryDTO>>(result);
        }
        public static ICollection<ProductDTO> GetProducts()
        {
            var request = WebRequest.Create($"{host}/getproducts") as HttpWebRequest;
            request.Method = "GET";
            request.ContentType = "application/json";

            var response = request.GetResponse() as HttpWebResponse;

            if (response?.StatusCode != HttpStatusCode.OK)
                return null;

            var streamReader = new StreamReader(response.GetResponseStream());
            var result = streamReader.ReadToEnd();

            return JsonSerializer.Deserialize<ICollection<ProductDTO>>(result);
        }
        public static ICollection<OrderDTO> GetOrders()
        {
            var request = WebRequest.Create($"{host}/getorders") as HttpWebRequest;
            request.Method = "GET";
            request.ContentType = "application/json";

            var response = request.GetResponse() as HttpWebResponse;

            if (response?.StatusCode != HttpStatusCode.OK)
                return null;

            var streamReader = new StreamReader(response.GetResponseStream());
            var result = streamReader.ReadToEnd();

            return JsonSerializer.Deserialize<ICollection<OrderDTO>>(result);
        }
        public static void SendOrder(OrderDTO order)
        {
            var request = WebRequest.Create($"{host}/addorder") as HttpWebRequest;
            request.CookieContainer = new CookieContainer();
            request.Method = "POST";
            request.ContentType = "application/json";
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                var json = JsonSerializer.Serialize(order);
                streamWriter.Write(json);
            }

            request.GetResponse();
        }
        public static void MarkOrderAsExecuted(OrderDTO order)
        {
            var request = WebRequest.Create($"{host}/executeorder") as HttpWebRequest;
            request.CookieContainer = new CookieContainer();
            request.Method = "POST";
            request.ContentType = "application/json";
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                var json = JsonSerializer.Serialize(order);
                streamWriter.Write(json);
            }

            request.GetResponse();
        }
    }
}
