namespace LifeTrack.Domain.Entities.Transaction
{
    public class TransactionCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int TypeId { get; set; }
    }
}
