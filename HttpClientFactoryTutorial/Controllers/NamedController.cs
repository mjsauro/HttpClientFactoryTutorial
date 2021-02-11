using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientFactoryTutorial.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NamedController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public NamedController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var client = _httpClientFactory.CreateClient("mocky");
            string result = await client.GetStringAsync("27e545aa-f6e6-4cf9-b8de-0e662dfbf100");
            return Ok(result);
        }
    }
}
