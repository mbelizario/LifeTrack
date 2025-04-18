using LifeTrack.Application.Interfaces;
using LifeTrack.Domain.Entities.Transaction;
using LifeTrack.Domain.Interfaces.Repositories;

namespace LifeTrack.Application.Services
{
    public class TransactionCategoryService : ITransactionCategoryService
    {
        private readonly ITransactionCategoryRepository _repository;

        public TransactionCategoryService(ITransactionCategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TransactionCategory>> GetByTypeAsync(int typeId)
        {
            var categories = await _repository.GetByTypeAsync(typeId);
            return categories;
        }
    }
}
