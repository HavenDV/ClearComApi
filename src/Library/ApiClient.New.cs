using System;
using System.Net.Http;
using System.Text;

namespace ClearComApi
{
    public partial class ApiClient : IDisposable
    {
        public HttpClient HttpClient { get; set; }

        public static ApiClient New(string baseUrl, string username, string password)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add(
                "Authorization", 
                $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"))}");

            return new ApiClient(baseUrl, client)
            {
                HttpClient = client
            };
        }

        public void Dispose()
        {
            HttpClient.Dispose();
        }
    }
}
