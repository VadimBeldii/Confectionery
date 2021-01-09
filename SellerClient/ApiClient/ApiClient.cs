using System.IO;
using System.Net;

namespace SellerClient
{
    class ApiClient: IApiClient
    {
        private readonly string host = "http://192.168.0.50:56424/api/seller";
        public string ProcessHttpGetRequest(string requestString)
        {
            var request = WebRequest.Create($"{host}/{requestString}") as HttpWebRequest;
            request.Method = "GET";
            request.ContentType = "application/json";

            var response = request.GetResponse() as HttpWebResponse;

            if (response?.StatusCode != HttpStatusCode.OK)
                return null;

            var streamReader = new StreamReader(response.GetResponseStream());
            return streamReader.ReadToEnd();
        }

        public WebResponse ProcessHttpPostRequest(string requestString, string requestData)
        {
            var request = WebRequest.Create($"{host}/{requestString}") as HttpWebRequest;
            request.CookieContainer = new CookieContainer();
            request.Method = "POST";
            request.ContentType = "application/json";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(requestData);
            }

            return request.GetResponse();
        }
    }
}
