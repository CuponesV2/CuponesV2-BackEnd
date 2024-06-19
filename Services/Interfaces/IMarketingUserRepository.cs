using Cupones.Models;
using Microsoft.AspNetCore.Mvc;
using Cupones.Dtos;

namespace Cupones.Services
{
    public interface IMarketingUserRepository
    {
        public object GetAll([FromQuery] int? page);
        
        public MarketingUser GetOne(int id);
        
        public void Create(MarketingUser marketingUser);

        public IActionResult Update(int id, [FromBody] MarketingUserDto marketingUserDto);
    }
}