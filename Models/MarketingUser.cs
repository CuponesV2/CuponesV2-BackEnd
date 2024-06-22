using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Cupones.Models
{
    public class MarketingUser
    {
        public int Id { get; set; }

        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public string? Email { get; set; }

        [JsonIgnore]
        public List<UserRole>? UserRole { get; set; }

        [JsonIgnore]
        public List<Coupon>? Coupon { get; set; }
    }
}