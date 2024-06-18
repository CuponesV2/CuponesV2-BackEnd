using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Cupones.Models
{
    public class CouponHistory
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int Coupon_id { get; set; }

        public Coupon? Coupon { get; set; }

        [Required]
        public DateOnly Change_date { get; set; }

        [Required]
        public string Field_Changed { get; set; }

        [Required]
        public string Old_Value { get; set; }

        [Required]
        public string New_Value { get; set; }

    }
}

