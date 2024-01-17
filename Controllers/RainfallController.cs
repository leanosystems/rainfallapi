using Microsoft.AspNetCore.Mvc;
using RainfallApi.Models;
using RainfallApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RainfallApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RainfallController : ControllerBase
    {
        private readonly IRainfallApiClient _rainfallApiClient;

        public RainfallController(IRainfallApiClient rainfallApiClient)
        {
            _rainfallApiClient = rainfallApiClient;
        }

        [HttpGet("id/{stationId}/readings")]
        public async Task<IActionResult> GetRainfallReadings(string stationId, [FromQuery] int count = 10)
        {
            try
            {
                var readings = await _rainfallApiClient.GetRainfallReadingsAsync(stationId, count);
                return Ok(readings);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, new ErrorResponseModel { Message = "Internal server error", Detail = new List<ErrorDetailModel>() });
            }
        }
    }
}
