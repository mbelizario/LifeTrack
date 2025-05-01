using Dapper;
using LifeTrack.Domain.Entities.Transaction;
using LifeTrack.Domain.Interfaces.Repositories;
using System.Data;


namespace LifeTrack.Infra.Data.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IDbConnection _dbConnection;

        public TransactionRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task InsertAsync(Transaction transaction)
        {
            var query = @"
                INSERT INTO LifeTrackDB.dbo.[Transaction] 
                    (Description, Amount, CategoryId, StatusId, TransactionDate)
                VALUES 
                    (@Description, @Amount, @CategoryId, @StatusId, @TransactionDate);";


            await _dbConnection.ExecuteAsync(query, transaction);
        }
    }
}
