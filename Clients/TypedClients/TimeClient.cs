using System;
using System.Net.Http;
using System.Threading.Tasks;
using Clients.Models;
using Newtonsoft.Json;

namespace Clients.TypedClients
{
    public interface ITimeClient
    {
        Task<string> GetTimezone();
        Task<string> GetCurrentTimeInTimezone(string area, string location);
        Task<string> GetCurrentTimeByIpAddress(string ipAddress);
    }

    public class TimeClient : ITimeClient
    {
        private readonly HttpClient _client;

        public TimeClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("http://worldtimeapi.org/api/");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            _client = httpClient;
        }

        public async Task<string> GetTimezone()
        {
            string responseString = string.Empty;
            try
            {
                var response = await _client.GetAsync("timezone");
                if (response.IsSuccessStatusCode)
                {
                    responseString = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<string[]>(responseString);
                    Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return responseString;
        }

        public async Task<string> GetCurrentTimeInTimezone(string area, string location)
        {
            string responseString = string.Empty;
            
            try
            {
                var response = await _client.GetAsync($"timezone/{area}/{location}");
                if (response.IsSuccessStatusCode)
                {
                    responseString = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Location>(responseString);
                    Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return responseString;
        }

        public async Task<string> GetCurrentTimeByIpAddress(string ipAddress)
        {
            string responseString = string.Empty;

            try
            {
               var response = await _client.GetAsync($"ip/{ipAddress}");
               if (response.IsSuccessStatusCode)
               {
                   responseString = await response.Content.ReadAsStringAsync();
                   var result = JsonConvert.DeserializeObject<IpAddress>(responseString);
                   Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));

               }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return responseString;
        }

    }
}
