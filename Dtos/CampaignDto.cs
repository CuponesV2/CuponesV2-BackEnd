namespace Cupones.Dtos;

public class CampaignDto
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateTime? Start_date { get; set; }

    public DateTime? End_date { get; set; }

    public int? CompanyId { get; set; }
}