using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TripAdvisor.Dto.Request;
using TripAdvisor.Service.Interfaces;

namespace TripAdvisor.API.Controllers
{
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public TripController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet]
        [Route("api/trip/suggest")]
        public async Task<IActionResult> FetchDistrictData([FromQuery] TripQueryParameters parameters)
        {
            return Ok("Success");
        }
    }
}
