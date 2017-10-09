using System.Threading.Tasks;

namespace KFIsher.Mobile.Services.Connection
{
    public interface IHttpConnection
    {
        /// <summary>
        /// Creates an HTTP GET request without authentication
        /// </summary>
        /// <param name="baseAddress"></param>
        /// <param name="url"></param>
        /// <returns><see cref="Task{HttpResponseMessage}"/></returns>
        Task<HttpResponse> GetData(string baseAddress, string url);
        
        /// <summary>
        /// Creates an HTTP GET request with authentication
        /// </summary>
        /// <param name="baseAddress"></param>
        /// <param name="url"></param>
        /// <param name="credentials"></param>
        /// <returns><see cref="Task{HttpResponseMessage}"/></returns>
        Task<HttpResponse> GetData(string baseAddress, string url, string token);

        /// <summary>
        /// Creates an HTTP POST request with authentication
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="baseAddress"></param>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="credentials"></param>
        /// <returns><see cref="Task{HttpResponseMessage}"/></returns>
        Task<HttpResponse> PutData<T>(string baseAddress, string url, T data, string token);

        /// <summary>
        /// Creates an HTTP POST request without authentication
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="baseAddress"></param>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns><see cref="Task{HttpResponseMessage}"/></returns>
        Task<HttpResponse> PutData<T>(string baseAddress, string url, T data);

        /// <summary>
        /// Creates an HTTP PUT request with authentication
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="baseAddress"></param>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="credentials"></param>
        /// <returns><see cref="Task{HttpResponseMessage}"/></returns>
        Task<HttpResponse> PostData<T>(string baseAddress, string url, T data, string token);

        /// <summary>
        /// Creates an HTTP PUT request without authentication
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="baseAddress"></param>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns><see cref="Task{HttpResponseMessage}"/></returns>
        Task<HttpResponse> PostData<T>(string baseAddress, string url, T data);
    }
}
