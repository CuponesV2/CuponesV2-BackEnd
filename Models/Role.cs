using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Cupones.Models
{
    public class Role
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [JsonIgnore]
        public List<UserRole>? UserRoles { get; set; }
    }
}