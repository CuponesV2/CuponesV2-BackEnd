using Cupones.Models;

namespace Cupones.Services
{
    public interface IMarketingUserRepository
    {
        public IEnumerable<MarketingUser> GetAll();
        
        public MarketingUser GetOne(int id);
        
        public void Create(MarketingUser marketingUser);
    }
}