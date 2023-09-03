using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripAdvisor.Dto.Response.OpenMeteo
{
    public class HourlyData
    {
        public IList<string> Time { get; set; }
        public IList<double> Temperature_2m { get; set; }
    }
}
