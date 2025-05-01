using LifeTrack.Application.DTOs;
using LifeTrack.Application.Interfaces;
using LifeTrack.Domain.Entities.Transaction;
using LifeTrack.Domain.Interfaces.Repositories;
using System.Globalization;

namespace LifeTrack.Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task InsertAsync(CreateTransactionInput input)
        {
            var transaction = new Transaction(
                input.Description,
                input.Amount,
                input.CategoryId,
                input.StatusId,
                DateTime.ParseExact(input.TransactionDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
            );

            await _transactionRepository.InsertAsync(transaction);
        }
    }
}
