using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripAdvisor.Db.Interfaces;
using TripAdvisor.Db.Models.ComplexTypes;
using TripAdvisor.Db.Models.Entities;
using TripAdvisor.Repository.Interfaces;

namespace TripAdvisor.Repository.Implementations
{
    public class DistrictTemperatureRepository : BaseRepository<DistrictTemperature>, IDistrictTemperatureRepository
    {
        public DistrictTemperatureRepository(IDbContext dbContext) : base(dbContext)
        {

        }

        
    }
}
