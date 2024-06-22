using Microsoft.EntityFrameworkCore;
using Cupones.Data;
using Cupones.Models;
using Microsoft.AspNetCore.Mvc;
using Cupones.Dtos;
using AutoMapper;

namespace Cupones.Services;

public class CampaignRepository : ICampaignRepository
{
    private readonly CuponesContext _context;

    private readonly IMapper _mapper;

    private readonly int records = 5;

    public CampaignRepository(CuponesContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public object GetAll([FromQuery] int? page)
    {
        int _page = page ?? 1;
        decimal totalRecords = _context.Campaigns.Count();
        int totalPages = Convert.ToInt32(Math.Ceiling(totalRecords / records));
        
        var companies = _context.Campaigns
            .Skip((_page - 1) * records)
            .Take(records)
            .ToList();
    
        var data = new { pages = totalPages,
                        currentPage = _page,
                        data = companies};
        
        return data;
    }

    public Campaign GetOne(int id)
    {
        return _context.Campaigns.Find(id);
    }

    public void Create(Campaign campaign)
    {
        _context.Campaigns.Add(campaign);
        _context.SaveChanges();
    }

    public IActionResult Update(int id, CampaignDto campaignDto)
    {
        var campaign = _context.Campaigns.Find(id);
        if (campaign == null)
        {
            return new NotFoundResult();
        }
        _mapper.Map(campaignDto, campaign);
        _context.SaveChanges();

        return new OkObjectResult(campaign);
    }
}

