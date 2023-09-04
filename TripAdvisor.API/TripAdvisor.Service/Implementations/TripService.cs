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
        private readonly IDistrictService _districtService;

        public TripService(IValidator<TripQueryParameters> validator, 
            IDistrictService districtService)
        {
            _validator = validator;
            _districtService = districtService;
        }


        public async Task<string> GetTripSuggestion(TripQueryParameters parameters)
        {
            var result = _validator.Validate(parameters);

            if (!result.IsValid)
            {
                throw new InvalidQueryParamsExceptions(string.Join(",", result.Errors.Select(e => e.ErrorMessage).ToList()));
            }

            double startingLocationTemperature = await _districtService.GetDistrictTemperature(parameters.StartingLocation, parameters.TravelDate);
            double destinationTemperature = await _districtService.GetDistrictTemperature(parameters.Destination, parameters.TravelDate);


            return destinationTemperature < startingLocationTemperature
                   ?
                    $"{parameters.Destination} is cooler than {parameters.StartingLocation}, you must visit the place"
                   :
                    $"{parameters.Destination} is hotter than {parameters.StartingLocation}, we suggest you to not visit the place";
        }
    }
}
