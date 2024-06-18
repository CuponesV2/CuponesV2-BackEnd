using Cupones.Models;

namespace Cupones.Services;

public interface IMarketplaceUserRepository
{
    public IEnumerable<MarketplaceUser> GetAll();

    public MarketplaceUser GetOne(int id);

    public void Create(MarketplaceUser marketplaceUser);
}