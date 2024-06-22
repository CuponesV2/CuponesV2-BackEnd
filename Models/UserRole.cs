using System.ComponentModel.DataAnnotations;

namespace Cupones.Models
{
    public class UserRole
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        public MarketingUser? MarketingUser { get; set; }
        
        [Required]
        public int RoleId { get; set; }

        public Role? Role { get; set; }
    }
}