using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Cupones.Models
{
    public class MarketingUser
    {
        [Required]
        public int id { get; set; }

        [Required]
        public string? username { get; set; }

        [Required]
        public string? password { get; set; }

        [Required]
        public string? email { get; set; }

        [JsonIgnore]
        public List<UserRole>? UserRoles { get; set; }
    }
}