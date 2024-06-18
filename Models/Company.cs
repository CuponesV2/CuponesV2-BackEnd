using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Cupones.Models;

public class Company
{
    [Required]
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    [Required]
    public required string Logo { get; set; }

    [Required]
    public required string Nit { get; set; }

    [JsonIgnore]
    public List<Campaign>? Campaigns { get; set; }
}