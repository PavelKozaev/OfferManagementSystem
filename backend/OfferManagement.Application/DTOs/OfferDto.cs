namespace OfferManagement.Application.DTOs
{
    public class OfferDto
    {
        public int Id { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string SupplierName { get; set; } = string.Empty; 
        public DateTime RegisteredAt { get; set; }
    }
}
