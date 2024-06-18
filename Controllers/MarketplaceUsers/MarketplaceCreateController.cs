using Microsoft.AspNetCore.Mvc;
using Cupones.Models;
using Cupones.Services;
using Microsoft.AspNetCore.Authorization;

namespace Cupones.AddControllers
{
    [ApiController]
    [Route("api/marketplaceUsers/create")]
    [Authorize]
    
    public class MarketplaceCreateController : ControllerBase
    {
        private readonly IMarketplaceUserRepository _marketplaceUserRepository;

        public MarketplaceCreateController(IMarketplaceUserRepository marketplaceUserRepository)
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