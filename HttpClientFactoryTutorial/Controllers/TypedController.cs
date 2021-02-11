using System;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("GoodGet")]
        public async Task<ActionResult> GoodGet()
        {
            string result = string.Empty;
            try
            {
                result = await _mockyClient.GetData();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                
            }
           
            return Ok(result);
        }

        [HttpGet("BadGet")]
        public async Task<ActionResult> BadGet()
        {
            string result = string.Empty;
            try
            {
                result = await _mockyClient.GetBadData();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
            return Ok(result);
        }
    }
}
