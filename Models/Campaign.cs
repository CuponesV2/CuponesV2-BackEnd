using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Cupones.Models;

public class Campaign
{
    [Required]
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    [Required]
    public required string Description { get; set; }

    [Required]
    public required DateOnly Start_date { get; set; }

    [Required]
    public required DateOnly End_date { get; set; }

    [Required]
    public required int CompanyId { get; set; }

    public Company? Company { get; set; }

    [JsonIgnore]
    public List<Coupon>? Coupons { get; set; }
}

