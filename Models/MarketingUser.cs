using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Cupones.Models
{
    public class MarketingUser
    {
        public int Id { get; set; }

        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public string? Email { get; set; }

        [JsonIgnore]
        public List<UserRole>? UserRoles { get; set; }

        [JsonIgnore]
        public List<Coupon>? Coupon { get; set; }
    }
}