namespace OfferManagement.Domain.Entities
{
    public class Offer : BaseEntity
    {
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; } = null!;
    }
}
