using Microsoft.EntityFrameworkCore;
using Cupones.Data;
using Cupones.Models;

namespace Cupones.Services;

public class MarketplaceUserRepository : IMarketplaceUserRepository
{
    private readonly CuponesContext _context;

    public MarketplaceUserRepository(CuponesContext context)
    {
        _context = context;
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
}