using LifeTrack.Domain.Entities.Transaction;

namespace LifeTrack.Domain.Interfaces.Repositories
{
    public interface ITransactionRepository
    {
        Task InsertAsync(Transaction transaction);
    }
}
