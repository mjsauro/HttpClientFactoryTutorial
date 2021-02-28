using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Clients.TypedClients
{
    public interface IIpClient
    {
        Task<string> GetIpAddress();
    }
    public class IpClient : IIpClient
    {
        private readonly HttpClient _client;

        public IpClient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://api.ipify.org");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            _client = client; 
        }

        public async Task<string> GetIpAddress()
        {
            string responseString = string.Empty;
            var response = await _client.GetAsync(_client.BaseAddress);
            if (response.IsSuccessStatusCode)
            {
                responseString = await response.Content.ReadAsStringAsync();
            }

            return responseString;
        }
    }
}