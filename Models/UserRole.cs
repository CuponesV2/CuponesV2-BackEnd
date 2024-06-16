using System.ComponentModel.DataAnnotations;

namespace Cupones.Models
{
    public class UserRole
    {
        [Required]
        public int id { get; set; }

        [Required]
        public int user_id { get; set; }

        public MarketingUser? MarketingUser { get; set; }
        
        [Required]
        public int role_id { get; set; }

        public Role Role { get; set; }
    }
}