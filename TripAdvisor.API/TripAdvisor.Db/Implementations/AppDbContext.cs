using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripAdvisor.Db.Interfaces;
using TripAdvisor.Db.Models;

namespace TripAdvisor.Db.Implementations
{
    public class AppDbContext : IDbContext
    {
        private readonly string connectionString;

        public AppDbContext(IOptions<ConnectionStrings> connectionsStringOptions)
        {
            connectionString = connectionsStringOptions.Value.DefaultConnection;
        }
        public async Task<IDbConnection> CreateConnectionAsync()
        {
            var sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();
            return sqlConnection;
        }
    }
}
