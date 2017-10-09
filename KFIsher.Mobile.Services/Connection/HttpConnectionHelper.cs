using ModernHttpClient;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace KFIsher.Mobile.Services.Connection
{
    public class HttpConnectionHelper
    {
        /// <summary>
        /// Build a http client with specific configuration
        /// </summary>
        /// <param name="baseAddress"></param>
        /// <returns></returns>
        public static HttpClient GetClient(string baseAddress, int timeout = ConnectionConfiguration.BaseRequestTimeout)
        {
            var client = new HttpClient(new NativeMessageHandler())
            {
                BaseAddress = new Uri(baseAddress),
                Timeout = TimeSpan.FromSeconds(timeout)
            };

            client.DefaultRequestHeaders.Accept.Clear();
            return client;
        }

        /// <summary>
        /// Add bearer authentication to http client
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="credentials"></param>
        public static void AddAuthorization(HttpClient httpClient, string token)
        {
            if (httpClient == null)
            {
                return;
            }

            var authValue = new AuthenticationHeaderValue("Bearer", token);
            httpClient.DefaultRequestHeaders.Authorization = authValue;
        }
    }
}
