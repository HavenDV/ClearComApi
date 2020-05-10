using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace ClearComApi
{
    public partial class ApiClient : IDisposable
    {
        public HttpClient? HttpClient { get; set; }

        public static ApiClient New(string baseUrl, string username, string password)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic", 
                Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{username}:{password}")));

            return new ApiClient(baseUrl, client)
            {
                HttpClient = client,
                //ReadResponseAsString = true,
            };
        }

        public void Dispose()
        {
            HttpClient?.Dispose();
        }
    }
}
