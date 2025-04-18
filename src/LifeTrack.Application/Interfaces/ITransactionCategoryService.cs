using LifeTrack.Domain.Entities.Transaction;

namespace LifeTrack.Application.Interfaces
{
    public interface ITransactionCategoryService
    {
        Task<IEnumerable<TransactionCategory>> GetByTypeAsync(int typeId);
    }
}
