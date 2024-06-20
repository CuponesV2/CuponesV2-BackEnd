using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Cupones.Models
{
    public class PurchaseCoupon
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int PurchaseId { get; set; }
        public Purchase? Purchase { get; set; }

        [Required]
        public int CouponId { get; set; }
        public Coupon? Coupon { get; set; }
    }
}