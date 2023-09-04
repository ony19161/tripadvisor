using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripAdvisor.Dto.Request;

namespace TripAdvisor.Service.Interfaces
{
    public interface ITripService
    {
        Task<string> GetTripSuggestion(TripQueryParameters parameters);
    }
}
