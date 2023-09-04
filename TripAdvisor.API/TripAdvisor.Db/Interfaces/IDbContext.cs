using System.Data;
using System.Data.Common;

namespace TripAdvisor.Db.Interfaces
{
    public interface IDbContext
    {
        Task<IDbConnection> CreateConnectionAsync();
    }
}
