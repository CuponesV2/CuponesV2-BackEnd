using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Cupones.Models
{
    public class Purchase
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int UserMarketplaceId { get; set; }
        public MarketplaceUser? MarketplaceUser { get; set; }

        [Required]
        public DateOnly Date { get; set; }

        [Required]
        public int Amount { get; set; }

        [JsonIgnore]
        public List<PurchaseCoupon>? PurchaseCoupons { get; set; }
    }
}

