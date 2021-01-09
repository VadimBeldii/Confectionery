using System.Net;

namespace SellerClient
{
    interface IApiClient
    {
        string ProcessHttpGetRequest(string requestString);
        WebResponse ProcessHttpPostRequest(string requestString, string requestData);
    }
}
