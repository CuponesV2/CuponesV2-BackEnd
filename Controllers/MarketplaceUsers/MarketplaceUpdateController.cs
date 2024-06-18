using Microsoft.AspNetCore.Mvc;
using Cupones.Dtos;
using Cupones.Services;
using Microsoft.AspNetCore.Authorization;

namespace Cupones.Controllers
{
    [ApiController]
    [Route("api/marketplaceUsers/update")]
    [Authorize]
    public class MarketplaceUpdateController : ControllerBase
    {
        private readonly IMarketplaceUserRepository _marketplaceUserRepository;

        public MarketplaceUpdateController(IMarketplaceUserRepository marketplaceUserRepository)
        {
            _marketplaceUserRepository = marketplaceUserRepository;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMarketplaceUser(int id, [FromBody] MarketplaceUserDto marketplaceUserDto)
        {
            if (marketplaceUserDto == null)
            {
                return BadRequest("La información del usuario de marketplace no puede ser nula");
            }

            try
            {
                var result = _marketplaceUserRepository.Update(id, marketplaceUserDto);
                return result;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar el usuario de marketplace: {ex.Message}");
            }
        }
    }
}