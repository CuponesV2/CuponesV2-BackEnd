using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Cupones.Models
{
    public class Role
    {
        [Required]
        public int id { get; set; }

        [Required]
        public string? name { get; set; }

        [JsonIgnore]
        public List<UserRole>? UserRoles { get; set; }
    }
}