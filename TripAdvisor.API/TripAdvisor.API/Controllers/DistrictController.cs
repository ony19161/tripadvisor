using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TripAdvisor.Dto.Response;

namespace TripAdvisor.API.Controllers
{
    
    [ApiController]
    public class DistrictController : ControllerBase
    {
        public DistrictController()
        {
            
        }

        [HttpGet]
        [Route("api/district/fetch-temperature-data")]
        public async Task<IActionResult> FetchTemperatureData()
        {
            ApiResponse<string> apiResponse = new()
            {
                Data = "Data fetched successfully"
            };

            return Ok(apiResponse);
        }

    }
}
