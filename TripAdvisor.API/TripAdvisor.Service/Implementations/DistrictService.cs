using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripAdvisor.Db.Models.ComplexTypes;
using TripAdvisor.Repository.Interfaces;
using TripAdvisor.Service.Interfaces;

namespace TripAdvisor.Service.Implementations
{
    public class DistrictService : IDistrictService
    {
        private readonly IDistrictTemperatureRepository _districtTemperatureRepository;

        public DistrictService(IDistrictTemperatureRepository districtTemperatureRepository)
        {
            _districtTemperatureRepository = districtTemperatureRepository;
        }

        public async Task<IList<CoolestDistrict>> GetTop10CoolestDistricts()
        {
            string query = "select top (10) District, ROUND(AVG(Temperature), 2) as AverageTemperature from DistrictTemperatures group by District order by AVG(Temperature)";
            var districtList = await _districtTemperatureRepository.GetListByQueryAsync<CoolestDistrict>(query);

            return districtList;
        }
    }
}
