using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientFactoryTutorial.TypedClients
{
    public interface IMockyClient
    {
        Task<string> GetData();
        Task<string> GetBadData();
    }
    public class MockyClient : IMockyClient
    {
        private readonly HttpClient _client;

        public MockyClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://run.mocky.io/v3/");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            _client = httpClient;
        }

        public async Task<string> GetData()
        {
            return await _client.GetStringAsync("27e545aa-f6e6-4cf9-b8de-0e662dfbf100");

        }

        public async Task<string> GetBadData()
        {
            return await _client.GetStringAsync("6cf3d54f-53ea-4a9d-8b7d-ff8b0a03ed70");
        }
    }
}
