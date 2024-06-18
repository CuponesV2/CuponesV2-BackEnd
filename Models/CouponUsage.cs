using System.ComponentModel.DataAnnotations;

namespace Cupones.Models
{
    public class CouponUsage
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int Coupon_id { get; set; }

        public Coupon? Coupon { get; set; }

        [Required]
        public int UserMarketplace_id { get; set; }

        public MarketingUser? MarketingUser { get; set; }

        [Required]
        public DateOnly Usage_date { get; set; }

        [Required]
        public string Transaction_amount { get; set; }
    }
}