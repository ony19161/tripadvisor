using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TripAdvisor.Dto.Config;
using TripAdvisor.Dto.Response.OpenMeteo;
using TripAdvisor.Service.Interfaces;

namespace TripAdvisor.Service.Implementations
{
    public class WeatherService : IWeatherService
    {
        private readonly TripAdvisorSettings tripAdvisorSettings;
        private readonly WeatherForecastApiSettings apiSettings;
        private readonly IHttpClientService _httpClientService;

        public WeatherService(IOptions<TripAdvisorSettings> tripAdvisorSettingsOptions,
            IOptions<WeatherForecastApiSettings> apiSettingsOptions,
            IHttpClientService httpClientService)
        {
            tripAdvisorSettings = tripAdvisorSettingsOptions.Value;
            apiSettings = apiSettingsOptions.Value;
            _httpClientService = httpClientService;
        }
        public async Task FetchDistrictsTemperature()
        {
            var list = tripAdvisorSettings.DistrictList.Where(d => d.Name.Equals("Dhaka") ||
                                                                   d.Name.Equals("Manikganj"))
                                                       .ToList();


            foreach (var item in list)
            {
                apiSettings.Parameters["latitude"] = item.Lat;
                apiSettings.Parameters["longitude"] = item.Long;

                var queryParams = string.Join("&", apiSettings.Parameters.Select(p => $"{p.Key}={p.Value}"));

                var apiResponse = await _httpClientService.SendGetRequest<OpenMetroGetResponse>(queryParams);
            }

        }
    }
}
