using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripAdvisor.Dto.Request;
using TripAdvisor.Repository.Interfaces;
using TripAdvisor.Service.Interfaces;

namespace TripAdvisor.Service.Implementations
{
    public class TripService : ITripService
    {
        private readonly IDistrictTemperatureRepository _districtTemperatureRepository;

        public TripService(IDistrictTemperatureRepository districtTemperatureRepository)
        {
            _districtTemperatureRepository = districtTemperatureRepository;
        }
        public async Task<string> GetTripSuggestion(TripQueryParameters parameters)
        {

            throw new NotImplementedException();
        }
    }
}
