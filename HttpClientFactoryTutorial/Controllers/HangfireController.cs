using Hangfire;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Clients.TypedClients;

namespace HttpClientFactoryTutorial.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HangfireController : ControllerBase
    {
        private readonly IBackgroundJobClient _backgroundJob;
        private readonly ITimeClient _timeClient;
        private readonly IIpClient _ipClient;

        public HangfireController(IBackgroundJobClient backgroundJob, ITimeClient timeClient, IIpClient ipClient)
        {
            _backgroundJob = backgroundJob;
            _timeClient = timeClient;
            _ipClient = ipClient;
        }

        [HttpGet("GetTimezone")]
        public ActionResult GetTimezone()
        {
            _backgroundJob.Enqueue(() => _timeClient.GetTimezone());
            return Ok("Get Timezone Request Acknowledged");
        }

        [HttpGet("GetCurrentTimeInZone")]
        public ActionResult GetCurrentTimeInTimezone(string area, string location)
        {
            _backgroundJob.Enqueue(() => _timeClient.GetCurrentTimeInTimezone(area, location));
            return Ok("Get Current Time In Zone Acknowledged");
        }

        [HttpGet("GetCurrentTimeByIpAddress")]
        public async Task<ActionResult> GetCurrentTimeZoneByIpAddressAsync(string ipAddress)
        {
            if (string.IsNullOrWhiteSpace(ipAddress))
            {
                ipAddress = await _ipClient.GetIpAddress();
            }
            
            _backgroundJob.Enqueue(() => _timeClient.GetCurrentTimeByIpAddress(ipAddress));
            return Ok("Get Current Time In Zone Acknowledged");
        }

    }
}
