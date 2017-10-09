using System.Net.Http;

namespace KFIsher.Mobile.Services.Connection
{
    public class HttpResponse
    {
        public HttpResponseMessage ResponseMessage { get; set; }

        public bool HasResult => ResponseMessage != null;

        public HttpResponse()
        {
        }

        public HttpResponse(HttpResponseMessage responseMessage)
        {
            ResponseMessage = responseMessage;
        }
    }
}
