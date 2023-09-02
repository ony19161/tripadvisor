using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripAdvisor.Dto.Config
{
    public class TripAdvisorSettings
    {
        public string WeatherForCastApiBaseUrl { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
        public IList<DistrictInfo> DistrictList { get; set; }
    }
}
