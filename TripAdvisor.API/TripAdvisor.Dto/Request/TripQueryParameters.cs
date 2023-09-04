using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripAdvisor.Dto.Request
{
    public class TripQueryParameters
    {
        public string StartingLocation { get; set; }
        public string Destination { get; set; }
        public string TravelDate { get; set; }
    }
}
