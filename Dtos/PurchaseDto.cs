namespace Cupones.Dtos
{
    public class PurchaseDto
    {
        public int Id { get; set; }
        public int? MarketplaceUserId { get; set; }
        public DateOnly? Date { get; set; }
        public int? Amount { get; set; }
    }
}