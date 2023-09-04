using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TripAdvisor.Db.Models.Entities;
using TripAdvisor.Dto.Config;
using TripAdvisor.Dto.Response.OpenMeteo;
using TripAdvisor.Repository.Interfaces;
using TripAdvisor.Service.Interfaces;

namespace TripAdvisor.Service.Implementations
{
    public class WeatherService : IWeatherService
    {
        private readonly TripAdvisorSettings _tripAdvisorSettings;
        private readonly WeatherForecastApiSettings _apiSettings;
        private readonly IHttpClientService _httpClientService;
        private readonly IDistrictTemperatureRepository _districtTemperatureRepository;

        public WeatherService(IOptions<TripAdvisorSettings> tripAdvisorSettingsOptions,
            IOptions<WeatherForecastApiSettings> apiSettingsOptions,
            IHttpClientService httpClientService,
            IDistrictTemperatureRepository districtTemperatureRepository)
        {
            _tripAdvisorSettings = tripAdvisorSettingsOptions.Value;
            _apiSettings = apiSettingsOptions.Value;
            _httpClientService = httpClientService;
            _districtTemperatureRepository = districtTemperatureRepository;
        }
        public async Task FetchDistrictsTemperature()
        {            

            foreach (var item in _tripAdvisorSettings.DistrictList)
            {
                _apiSettings.Parameters["latitude"] = item.Lat;
                _apiSettings.Parameters["longitude"] = item.Long;

                var queryParams = string.Join("&", _apiSettings.Parameters.Select(p => $"{p.Key}={p.Value}"));

                var apiResponse = await _httpClientService.SendGetRequest<OpenMetroGetResponse>(queryParams);

                IList<DistrictTemperature> sDistrictTemperatures = MapToDistrictTemperatures(item.Name, apiResponse);

                if (!ReferenceEquals(sDistrictTemperatures, null) && sDistrictTemperatures.Any())
                {
                    try
                    {
                        await _districtTemperatureRepository.BulkInsertAsync(sDistrictTemperatures);
                    }
                    catch (Exception ex)
                    {
                        // TODO: Add logger
                        await Console.Out.WriteLineAsync(ex.Message);
                    }
                }
            }

        }

        private IList<DistrictTemperature> MapToDistrictTemperatures(string districtName, OpenMetroGetResponse openMetroResponse)
        {
            IList<DistrictTemperature> districtTemperatures = new List<DistrictTemperature>();
            string targetTime = "T14:00";
            Dictionary<DateTime, double> temperaturesInTime = MapDateAndTemperature(openMetroResponse, targetTime);

            foreach (var item in temperaturesInTime)
            {
                districtTemperatures.Add(new DistrictTemperature
                {
                    District = districtName,
                    Date = item.Key,
                    Time = targetTime.Replace("T", ""),
                    Temperature = item.Value,
                    Unit = openMetroResponse.Hourly_units.Temperature_2m
                });
            }

            return districtTemperatures;
        }

        public Dictionary<DateTime, double> MapDateAndTemperature(OpenMetroGetResponse openMetroResponse, string targetTime)
        {
            Dictionary<DateTime, double> resultSet = new Dictionary<DateTime, double>();
            
            

            for (int i = 0; i < openMetroResponse.Hourly.Time.Count; i++)
            {
                if (openMetroResponse.Hourly.Time[i].IndexOf(targetTime) > 0)
                {
                    var dateString = openMetroResponse.Hourly.Time[i].Split('T');
                    var datetime = DateTime.ParseExact(dateString[0] + " " + dateString[1], "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
                    resultSet.Add(datetime, openMetroResponse.Hourly.Temperature_2m[i]);
                }
            }

            return resultSet;
        }
    }
}
