using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Cupones.Models
{
    public class PurchaseCoupon
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int Purchase_id { get; set; }
        public Purchase? Purchase { get; set; }

        [Required]
        public int Coupon_id { get; set; }
        public Coupon? Coupon { get; set; }
    }
}