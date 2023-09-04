using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TripAdvisor.Db.Models.ComplexTypes;
using TripAdvisor.Dto.Response;
using TripAdvisor.Service.Interfaces;

namespace TripAdvisor.API.Controllers
{
    
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly IWeatherService _weatherService;
        private readonly IDistrictService _districtService;

        public DistrictController(IWeatherService weatherService,
            IDistrictService districtService)
        {
            _weatherService = weatherService;
            _districtService = districtService;
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


        [HttpGet]
        [Route("api/district/coolest10")]
        public async Task<IActionResult> GetTop10CoolestDisticts()
        {
            ApiResponse<IList<CoolestDistrict>> apiResponse = new()
            {
                Data = await _districtService.GetTop10CoolestDistricts()
            };

            return Ok(apiResponse);
        }

    }
}
