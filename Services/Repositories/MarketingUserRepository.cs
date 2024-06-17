using Microsoft.EntityFrameworkCore;
using Cupones.Data;
using Cupones.Models;

namespace Cupones.Services
{
    public class MarketingUserRepository : IMarketingUserRepository
    {
        private readonly CuponesContext _context;

        public MarketingUserRepository(CuponesContext context)
        {
            _context = context;
        }

        public IEnumerable<MarketingUser> GetAll()
        {
            return _context.MarketingUsers.ToList();
        }

        public MarketingUser GetOne(int id)
        {
            return _context.MarketingUsers.Find(id);
        }

        public void Create(MarketingUser marketingUser)
        {
            _context.MarketingUsers.Add(marketingUser);
            _context.SaveChanges();
        }
    }
}