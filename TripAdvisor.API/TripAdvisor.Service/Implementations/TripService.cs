using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripAdvisor.Dto.Request;
using TripAdvisor.Repository.Interfaces;
using TripAdvisor.Service.CustomExceptions;
using TripAdvisor.Service.Interfaces;

namespace TripAdvisor.Service.Implementations
{
    public class TripService : ITripService
    {
        private readonly IValidator<TripQueryParameters> _validator;
        private readonly IDistrictTemperatureRepository _districtTemperatureRepository;

        public TripService(IValidator<TripQueryParameters> validator, IDistrictTemperatureRepository districtTemperatureRepository)
        {
            _validator = validator;
            _districtTemperatureRepository = districtTemperatureRepository;
        }


        public async Task<string> GetTripSuggestion(TripQueryParameters parameters)
        {
            var result = _validator.Validate(parameters);

            if (!result.IsValid)
            {
                throw new InvalidQueryParamsExceptions(string.Join(",", result.Errors.Select(e => e.ErrorMessage).ToList()));
            }

            return "valid";
        }
    }
}
