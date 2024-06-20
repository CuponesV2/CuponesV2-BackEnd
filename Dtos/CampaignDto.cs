namespace Cupones.Dtos;

public class CampaignDto
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateOnly? Start_date { get; set; }

    public DateOnly? End_date { get; set; }

    public int? CompanyId { get; set; }
}