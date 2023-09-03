using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripAdvisor.Dto.Response.OpenMeteo
{
    public class OpenMetroGetResponse
    {
        public HourlyUnitData Hourly_units { get; set; }
        public HourlyData Hourly { get; set; }
    }
}
