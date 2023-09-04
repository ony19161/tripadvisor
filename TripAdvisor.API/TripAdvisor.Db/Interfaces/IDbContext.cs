using SqlKata.Execution;
using System.Data;

namespace TripAdvisor.Db.Interfaces
{
    public interface IDbContext
    {
        Task<IDbConnection> CreateConnectionAsync();
        QueryFactory GetDb(IDbConnection connection);
    }
}
