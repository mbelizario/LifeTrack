using LifeTrack.Domain.Entities.Transaction;

namespace LifeTrack.Domain.Interfaces.Repositories
{
    public interface ITransactionCategoryRepository
    {
        Task<IEnumerable<TransactionCategory>> GetByTypeAsync(int typeId);
    }
}
