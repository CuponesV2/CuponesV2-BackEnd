using Cupones.Dtos;
using Cupones.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cupones.Services;

public interface IMarketplaceUserRepository
{
    public object GetAll([FromQuery] int? page);

    public MarketplaceUser GetOne(int id);

    public void Create(MarketplaceUser marketplaceUser);

    public IActionResult Update(int id, [FromBody] MarketplaceUserDto marketplaceUserDto);
}