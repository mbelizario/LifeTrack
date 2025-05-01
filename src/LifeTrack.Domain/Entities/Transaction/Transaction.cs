namespace LifeTrack.Domain.Entities.Transaction
{
    public class Transaction
    {
        public int Id { get; private set; }
        public string Description { get; private set; }
        public decimal Amount { get; private set; }
        public int CategoryId { get; private set; }
        public int StatusId { get; private set; }
        public DateTime TransactionDate { get; private set; }

        public Transaction(string description, decimal amount, int categoryId, int statusId, DateTime transactionDate)
        {
            Description = description;
            Amount = amount;
            CategoryId = categoryId;
            StatusId = statusId;
            TransactionDate = transactionDate;
        }
    }
}
