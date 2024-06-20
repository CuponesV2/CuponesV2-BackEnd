using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Cupones.Models
{
    public class CouponHistory
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int CouponId { get; set; }

        public Coupon? Coupon { get; set; }

        [Required]
        public DateOnly Change_date { get; set; }

        [Required]
        public string Field_changed { get; set; }

        [Required]
        public string Old_value { get; set; }

        [Required]
        public string New_value { get; set; }

    }
}

