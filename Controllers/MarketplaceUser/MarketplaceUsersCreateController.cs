using Microsoft.AspNetCore.Mvc;
using Cupones.Models;
using Cupones.Services;

namespace Cupones.AddControllers
{
    [ApiController]
    [Route("api/marketplaceUsers/create")]
    
    public class MarketplaceUsersCreateController : ControllerBase
    {
        private readonly IMarketplaceUserRepository _marketplaceUserRepository;

        public MarketplaceUsersCreateController(IMarketplaceUserRepository marketplaceUserRepository)
        {
            _marketplaceUserRepository = marketplaceUserRepository;
        }

        [HttpPost]
        public IActionResult CreateMarketplaceUser(MarketplaceUser marketplaceUser)
        {
            if (marketplaceUser == null)
            {
                return BadRequest("El usuario de marketplace no puede ser nulo");
            }
            try
            {
                _marketplaceUserRepository.Create(marketplaceUser);
                return Ok(marketplaceUser);

            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear el usuario de marketplace: {ex.Message}");
            }
        }
    }
}