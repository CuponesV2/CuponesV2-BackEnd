using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Cupones.Models;

public class MarketplaceUser
{
    [Required]
    public int Id { get; set; }

    [Required]
    public required string Username { get; set; }

    [Required]
    public required string Password { get; set; }

    [Required]
    public required string Email { get; set; }
     [JsonIgnore]
    public List<CouponUsage>? CouponUsage { get; set; }
     public List<Purchase>? Purchase { get; set; }
}