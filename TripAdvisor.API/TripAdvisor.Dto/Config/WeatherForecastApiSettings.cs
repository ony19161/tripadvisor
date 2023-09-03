using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripAdvisor.Dto.Config
{
    public class WeatherForecastApiSettings
    {
        public string WeatherFordCastApiBaseUrl { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
    }
}
