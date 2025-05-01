using LifeTrack.Application.DTOs;

namespace LifeTrack.Application.Interfaces
{
    public interface ITransactionService
    {
        Task InsertAsync(CreateTransactionInput input);
    }
}
