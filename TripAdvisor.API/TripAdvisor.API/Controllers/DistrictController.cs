using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TripAdvisor.Dto.Response;
using TripAdvisor.Service.Interfaces;

namespace TripAdvisor.API.Controllers
{
    
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public DistrictController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet]
        [Route("api/district/fetch-temperature-data")]
        public async Task<IActionResult> FetchTemperatureData()
        {
            await _weatherService.FetchDistrictsTemperature();
            ApiResponse<string> apiResponse = new()
            {
                Data = "Data fetched successfully"
            };

            return Ok(apiResponse);
        }

    }
}
