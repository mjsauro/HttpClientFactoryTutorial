using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HttpClientFactoryTutorial.TypedClients;

namespace HttpClientFactoryTutorial.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TypedController : ControllerBase
    {

        private readonly IMockyClient _mockyClient;

        public TypedController(IMockyClient mockyClient)
        {
            _mockyClient = mockyClient;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _mockyClient.GetData();
            return Ok(result);
        }

        [HttpGet("BadGet")]
        public async Task<ActionResult> BadGet()
        {
            var result = await _mockyClient.GetBadData();
            return Ok(result);
        }
    }
}
