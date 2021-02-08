using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientFactoryTutorial.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DirectController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DirectController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://run.mocky.io/v3/27e545aa-f6e6-4cf9-b8de-0e662dfbf100");
            string result = await client.GetStringAsync(client.BaseAddress);
            return Ok(result);
        }

    }
}
