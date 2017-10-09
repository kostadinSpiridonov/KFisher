using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using KFIsher.Mobile.Services.Connection;

namespace KFIsher.Mobile.Services.Helpers
{
    public static class JsonHelper
    {
        /// <summary>
        /// Serialize http response content to specific object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response"></param>
        /// <returns></returns>
        public static Task<T> Serialize<T>(HttpResponse response)
        {
            if (response?.ResponseMessage == null)
            {
                return null;
            }

            return response.ResponseMessage.Content
                .ReadAsStringAsync()
                .ContinueWith(x => JsonConvert.DeserializeObject<T>(x.Result));
        }
    }
}
