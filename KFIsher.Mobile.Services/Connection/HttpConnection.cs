using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace KFIsher.Mobile.Services.Connection
{
    public class HttpConnection : IHttpConnection
    {
        /// <summary>
        /// Creates an HTTP GET request without authentication
        /// </summary>
        /// <param name="baseAddress"></param>
        /// <param name="url"></param>
        /// <returns><see cref="Task{HttpResponseMessage}"/></returns>
        public Task<HttpResponse> GetData(string baseAddress, string url)
        {
            var httpClient = HttpConnectionHelper.GetClient(baseAddress);
            return SendHttpRequestAsync(RequestType.GET, url, new { }, httpClient);
        }

        /// <summary>
        /// Creates an HTTP GET request with authentication
        /// </summary>
        /// <param name="baseAddress"></param>
        /// <param name="url"></param>
        /// <param name="credentials"></param>
        /// <returns><see cref="Task{HttpResponseMessage}"/></returns>
        public Task<HttpResponse> GetData(string baseAddress, string url, string token)
        {
            var httpClient = HttpConnectionHelper.GetClient(baseAddress);
            HttpConnectionHelper.AddAuthorization(httpClient, token);

            return SendHttpRequestAsync(RequestType.GET, url, new { }, httpClient);
        }

        /// <summary>
        /// Creates an HTTP POST request with authentication
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="baseAddress"></param>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="credentials"></param>
        /// <returns><see cref="Task{HttpResponseMessage}"/></returns>
        public Task<HttpResponse> PostData<T>(string baseAddress, string url, T data, string token)
        {
            var httpClient = HttpConnectionHelper.GetClient(baseAddress);
            HttpConnectionHelper.AddAuthorization(httpClient, token);

            return SendHttpRequestAsync(RequestType.POST, url, data, httpClient);
        }

        /// <summary>
        /// Creates an HTTP POST request without authentication
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="baseAddress"></param>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns><see cref="Task{HttpResponseMessage}"/></returns>
        public Task<HttpResponse> PostData<T>(string baseAddress, string url, T data)
        {
            var httpClient = HttpConnectionHelper.GetClient(baseAddress);
            return SendHttpRequestAsync(RequestType.POST, url, data, httpClient);
        }

        /// <summary>
        /// Creates an HTTP PUT request with authentication
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="baseAddress"></param>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="credentials"></param>
        /// <returns><see cref="Task{HttpResponseMessage}"/></returns>
        public Task<HttpResponse> PutData<T>(string baseAddress, string url, T data, string token)
        {
            var httpClient = HttpConnectionHelper.GetClient(baseAddress);
            HttpConnectionHelper.AddAuthorization(httpClient, token);

            return SendHttpRequestAsync(RequestType.PUT, url, data, httpClient);
        }

        /// <summary>
        /// Creates an HTTP PUT request without authentication
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="baseAddress"></param>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns><see cref="Task{HttpResponseMessage}"/></returns>
        public Task<HttpResponse> PutData<T>(string baseAddress, string url, T data)
        {
            var httpClient = HttpConnectionHelper.GetClient(baseAddress);
            return SendHttpRequestAsync(RequestType.PUT, url, data, httpClient);
        }

        /// <summary>
        /// Generic HTTP request builder
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestType"></param>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="httpClient"></param>
        /// <returns><see cref="Task{HttpResponseMessage}"/></returns>
        private async Task<HttpResponse> SendHttpRequestAsync<T>(RequestType requestType, string url, T data, HttpClient httpClient)
        {
            try
            {
                HttpResponseMessage httpResponse = null;
                using (httpClient)
                {
                    // Set request content type header
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Serialize the object to json and ignore the null value variables
                    var json = JsonConvert.SerializeObject(
                        data,
                        Formatting.None,
                        new JsonSerializerSettings
                        {
                            NullValueHandling = NullValueHandling.Ignore
                        });

                    // Create the request content
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    switch (requestType)
                    {
                        case RequestType.POST:
                            httpResponse = await httpClient.PostAsync(url, content);
                            break;
                        case RequestType.PUT:
                            httpResponse = await httpClient.PutAsync(url, content);
                            break;
                        case RequestType.GET:
                            httpResponse = await httpClient.GetAsync(url);
                            break;
                    }
                }

                httpClient.Dispose();
                return new HttpResponse(httpResponse);
            }
            catch (Exception exception)
            {
                // Invoke the failed http request event
                ConnectionEvents.InvokeErrorEvent(null, new ErrorEventArgs(exception, exception?.Message));
            }
            finally
            {
                httpClient.Dispose();
            }

            return new HttpResponse();
        }
    }
}

