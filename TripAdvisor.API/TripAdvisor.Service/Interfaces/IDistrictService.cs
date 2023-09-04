using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripAdvisor.Db.Models.ComplexTypes;

namespace TripAdvisor.Service.Interfaces
{
    public interface IDistrictService
    {
        Task<IList<CoolestDistrict>> GetTop10CoolestDistricts();
    }
}
