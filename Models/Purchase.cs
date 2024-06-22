using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Cupones.Models
{
    public class Purchase
    {
        public int Id { get; set; }

        [Required]
        public int MarketplaceUserId { get; set; }
        public MarketplaceUser? MarketplaceUser { get; set; }

        [Required]
        public DateOnly Date { get; set; }

        [Required]
        public int Amount { get; set; }

        [JsonIgnore]
        public List<PurchaseCoupon>? PurchaseCoupon { get; set; }
    }
}

