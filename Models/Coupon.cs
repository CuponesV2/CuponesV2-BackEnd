using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Cupones.Models
{
    public class Coupon
    {
        [Required]
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

        [Required]
        public int Created_By { get; set; }
        public MarketingUser?  MarketingUser { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public int CampaignId { get; set; }

        public Campaign? Campaign { get; set; }

        [JsonIgnore]
        public List<CouponHistory>? CouponHistory { get; set; }

        [JsonIgnore]
        public List<CouponUsage>? CouponUsage { get; set; }

        [JsonIgnore]
        public List<PurchaseCoupon>? PurchaseCoupon { get; set; }
    }
}