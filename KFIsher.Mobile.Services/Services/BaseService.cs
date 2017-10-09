using KFIsher.Mobile.Services.Connection;
using System.Threading.Tasks;

namespace KFIsher.Mobile.Services.Services
{
    public abstract class BaseService
    {
        private readonly IHttpConnection httpConnection;

        protected string BaseAddress { get; set; }

        public BaseService(string baseAddress, IHttpConnection httpConnection)
        {
            this.BaseAddress = baseAddress;
            this.httpConnection = httpConnection;
        }

        public BaseService(IHttpConnection httpConnection)
        {
            this.BaseAddress = ConnectionConfiguration.ApiAddress;
            this.httpConnection = httpConnection;
        }

        /// <summary>
        /// Creates an HTTP GET request async without authentication
        /// </summary>
        /// <param name="url"></param>
        /// <returns><see cref="Task{HttpResponseMessage}"/></returns>
        public Task<HttpResponse> GetRequestAsync(string url)
        {
            return this.httpConnection.GetData(this.BaseAddress, url);
        }

        /// <summary>
        /// Creates an HTTP GET request async with authentication
        /// </summary>
        /// <param name="url"></param>
        /// <param name="credentials"></param>
        /// <returns><see cref="Task{HttpResponseMessage}"/></returns>
        public Task<HttpResponse> GetRequestAsync(string url, string token)
        {
            return this.httpConnection.GetData(this.BaseAddress, url, token);
        }

        /// <summary>
        /// Creates an HTTP PUT request async with authentication
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="credentials"></param>
        /// <returns><see cref="Task{HttpResponseMessage}"/></returns>
        public Task<HttpResponse> PutRequestAsync<T>(string url, T data, string token)
        {
            return this.httpConnection.PutData(this.BaseAddress, url, data, token);
        }

        /// <summary>
        /// Creates an HTTP PUT request async without authentication
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns><see cref="Task{HttpResponseMessage}"/></returns>
        public Task<HttpResponse> PutRequestAsync<T>(string url, T data)
        {
            return this.httpConnection.PutData(this.BaseAddress, url, data);
        }

        /// <summary>
        /// Creates an HTTP POST request async with authentication
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="credentials"></param>
        /// <param name="timeout">Request timeount in seconds</param>
        /// <returns><see cref="Task{HttpResponseMessage}"/></returns>
        public Task<HttpResponse> PostRequestAsync<T>(string url, T data, string token)
        {
            return this.httpConnection.PostData(this.BaseAddress, url, data, token);
        }

        /// <summary>
        /// Creates an HTTP POST request async without authentication
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns><see cref="Task{HttpResponseMessage}"/></returns>
        public Task<HttpResponse> PostRequestAsync<T>(string url, T data)
        {
            return this.httpConnection.PostData(this.BaseAddress, url, data);
        }
    }
}
