using FluentValidation;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripAdvisor.Dto.Config;
using TripAdvisor.Dto.Request;

namespace TripAdvisor.Service.Validators
{
    public class TripQueryValidator : AbstractValidator<TripQueryParameters>
    {
        private readonly TripAdvisorSettings _tripAdvisorSettings;
        private DateTime tripDate;
        public TripQueryValidator(IOptions<TripAdvisorSettings> tripAdvisorSettingsOptions)
        {
            _tripAdvisorSettings = tripAdvisorSettingsOptions.Value;

            RuleFor(q => q.StartingLocation).NotEmpty()
                                            .NotNull()
                                            .Must(IsValidDistrict)
                                            .WithMessage("Invalid starting location");

            RuleFor(q => q.Destination).NotEmpty()
                                       .NotNull()
                                       .Must(IsValidDistrict)
                                       .WithMessage("Invalid destination location");

            RuleFor(q => q.TravelDate).NotEmpty()
                                      .NotNull()
                                      .Must(IsValidDateFormat)
                                      .WithMessage("Invalid date format")
                                      .Must(IsValidTripdate)
                                      .WithMessage("Trip date must be withing next 7 days");
        }

        private bool IsValidDistrict(string name)
        {
            DistrictInfo value = _tripAdvisorSettings.DistrictList.FirstOrDefault(d => d.Name.ToLower().Equals(name.ToLower()));

            return !ReferenceEquals(value, null);
        }


        private bool IsValidDateFormat(string dateString)
        {
            return DateTime.TryParseExact(dateString, "dd/MM/yyyy", CultureInfo.InstalledUICulture, DateTimeStyles.AssumeLocal, out tripDate);
        }

        private bool IsValidTripdate(string date)
        {
            DateTime sevenDaysFromNow = DateTime.Now.AddDays(6);

            return tripDate <= sevenDaysFromNow;
        }
    }
}
