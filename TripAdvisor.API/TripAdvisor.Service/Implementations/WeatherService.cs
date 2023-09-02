using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripAdvisor.Dto.Config;
using TripAdvisor.Service.Interfaces;

namespace TripAdvisor.Service.Implementations
{
    public class WeatherService : IWeatherService
    {
        private readonly TripAdvisorSettings tripAdvisorSettings;
        public WeatherService(IOptions<TripAdvisorSettings> tripAdvisorSettingsOptions)
        {
            tripAdvisorSettings = tripAdvisorSettingsOptions.Value;
        }
        public Task FetchDistrictsForcast()
        {
            throw new NotImplementedException();
        }
    }
}
