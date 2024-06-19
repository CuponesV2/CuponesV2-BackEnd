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
        private readonly SlackNotifier _slackNotifier;

        public MarketplaceUpdateController(IMarketplaceUserRepository marketplaceUserRepository, SlackNotifier slackNotifier)
        {
            _marketplaceUserRepository = marketplaceUserRepository;
            _slackNotifier = slackNotifier;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMarketplaceUser(int id, [FromBody] MarketplaceUserDto marketplaceUserDto)
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
                await _slackNotifier.NotifyAsync(ex.StackTrace);
                return StatusCode(500, $"Error al actualizar el usuario de marketplace: {ex.Message}");
            }
        }
    }
}