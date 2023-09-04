using Dapper;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Common;
using System.Reflection;
using TripAdvisor.Db.Interfaces;
using TripAdvisor.Repository.Interfaces;

namespace TripAdvisor.Repository.Implementations
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public readonly IDbContext dbContext;

        public BaseRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IList<TEntity>> GetAllAsync()
        {
            using IDbConnection dbConnection = await dbContext.CreateConnectionAsync();
            return (await dbConnection.GetListAsync<TEntity>()).ToList();
        }

        public async Task<TEntity> GetByIdAsync<IdType>(IdType id)
        {
            using var dbConnection = await dbContext.CreateConnectionAsync();
            var entity = await dbConnection.GetAsync<TEntity>(id);

            return entity;
        }

        public async Task<int> InsertAsync(TEntity entity)
        {
            using var dbConnection = await dbContext.CreateConnectionAsync();
            return (int)(await dbConnection.InsertAsync(entity));
        }

        public Task<int> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IList<ReturnType>> FetchListBySPAsync<ReturnType, P>(string storedProcedureName, P parameters)
        {
            throw new NotImplementedException();
        }

        public async Task BulkInsertAsync(IList<TEntity> entities)
        {
            using var dbConnection = await dbContext.CreateConnectionAsync();

            foreach (var entity in entities)
            {
                await dbConnection.InsertAsync(entity);
            }
        }

        public async Task<IList<T>> GetListByQueryAsync<T>(string query)
        {
            using var dbConnection = await dbContext.CreateConnectionAsync();

            var resultSet = await dbConnection.QueryAsync<T>(query);

            return resultSet.ToList();
        }
    }
}
