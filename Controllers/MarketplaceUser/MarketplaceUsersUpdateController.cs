using Microsoft.AspNetCore.Mvc;
using Cupones.Dtos;
using Cupones.Services;

namespace Cupones.Controllers
{
    [ApiController]
    [Route("api/marketplaceUsers/update")]
    public class MarketplaceUsersUpdateController : ControllerBase
    {
        private readonly IMarketplaceUserRepository _marketplaceUserRepository;

        public MarketplaceUsersUpdateController(IMarketplaceUserRepository marketplaceUserRepository)
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