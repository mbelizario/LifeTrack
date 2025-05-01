using System.Text.Json.Serialization;

namespace LifeTrack.Application.DTOs
{
    public class CreateTransactionInput
    {
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public int CategoryId { get; set; }
        public int StatusId { get; set; }
        public string TransactionDate { get; set; } = string.Empty;
    }
}
