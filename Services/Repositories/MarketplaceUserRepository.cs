using Microsoft.EntityFrameworkCore;
using Cupones.Data;
using Cupones.Models;
using Microsoft.AspNetCore.Mvc;
using Cupones.Dtos;
using AutoMapper;

namespace Cupones.Services;

public class MarketplaceUserRepository : IMarketplaceUserRepository
{
    private readonly CuponesContext _context;

    private readonly IMapper _mapper;

    public MarketplaceUserRepository(CuponesContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<MarketplaceUser> GetAll()
    {
        return _context.MarketplaceUsers.ToList();
    }

    public MarketplaceUser GetOne(int id)
    {
        return _context.MarketplaceUsers.Find(id);
    }

    public void Create(MarketplaceUser marketplaceUser)
    {
        _context.MarketplaceUsers.Add(marketplaceUser);
        _context.SaveChanges();
    }

    public IActionResult Update(int id, MarketplaceUserDto marketplaceUserDto)
    {
        var marketplaceUser = _context.MarketplaceUsers.Find(id);
        if (marketplaceUser == null)
        {
            return new NotFoundResult();
        }
        _mapper.Map(marketplaceUserDto, marketplaceUser);
        _context.SaveChanges();

        return new OkObjectResult(marketplaceUser);
    }
}