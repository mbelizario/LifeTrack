using Dapper;
using LifeTrack.Domain.Entities.Transaction;
using LifeTrack.Domain.Interfaces.Repositories;
using System.Data;

namespace LifeTrack.Infra.Data.Repositories
{
    public class TransactionCategoryRepository : ITransactionCategoryRepository
    {
        private readonly IDbConnection _dbConnection;

        public TransactionCategoryRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<TransactionCategory>> GetByTypeAsync(int typeId)
        {
            const string sql = @"SELECT Id,
                                       Name,
                                       TypeId
                                FROM LifeTrackDB.dboTransactionCategory
                                WHERE TypeId = @typeId";

            var result = await _dbConnection.QueryAsync<TransactionCategory>(sql);
            return result;
        }
    }
}
