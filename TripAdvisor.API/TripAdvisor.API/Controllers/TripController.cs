using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TripAdvisor.Dto.Request;
using TripAdvisor.Dto.Response;
using TripAdvisor.Service.CustomExceptions;
using TripAdvisor.Service.Interfaces;

namespace TripAdvisor.API.Controllers
{
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly ITripService _tripService;

        public TripController(ITripService tripService)
        {
            _tripService = tripService;
        }

        [HttpGet]
        [Route("api/trip/suggest")]
        public async Task<IActionResult> FetchDistrictData([FromQuery] TripQueryParameters parameters)
        {
            try
            {
                ApiResponse<string> apiResponse = new ApiResponse<string>();
                apiResponse.Data = await _tripService.GetTripSuggestion(parameters);

                return Ok(apiResponse);
            }
            catch (InvalidQueryParamsExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                return BadRequest(ex.Message);
            }
            
        }
    }
}
