using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Cupones.Models
{
    public class Coupon
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateOnly Start_date { get; set; }

        [Required]
        public DateOnly End_date { get; set; }

        [Required]
        public string Discount_type { get; set; }

        [Required]
        public int Discount_value { get; set; }

        [Required]
        public int Usage_limit { get; set; }

        [Required]
        public int Min_purchase_amount { get; set; }

        [Required]
        public int Max_purchase_amount { get; set; }

        [Required]
        public string Status { get; set; }

        public int? CreatedBy { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public int CampaignId { get; set; }

        public Campaign? Campaign { get; set; }
 
        [JsonIgnore]
        public List<CouponHistory>? CouponHistories { get; set; }

        [JsonIgnore]
        public List<CouponUsage>? CouponUsages { get; set; }
 
        [JsonIgnore]
         public List<PurchaseCoupon>? PurchaseCoupons { get; set; } 
         public MarketingUser? MarketingUser { get; set; }
    }
}

