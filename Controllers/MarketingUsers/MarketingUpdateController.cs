using Microsoft.AspNetCore.Mvc;
using Cupones.Dtos;
using Cupones.Services;
using Microsoft.AspNetCore.Authorization;

namespace Cupones.AddControllers
{
    [ApiController]
    [Route("api/marketingusers/update")]
    [Authorize]
    public class MarketingUpdateController : ControllerBase
    {
        private readonly IMarketingUserRepository _marketingUserRepository;
        private readonly SlackNotifier _slackNotifier;

        public MarketingUpdateController(IMarketingUserRepository marketingUserRepository, SlackNotifier slackNotifier)
        {
            _marketingUserRepository = marketingUserRepository;
            _slackNotifier = slackNotifier;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMarketingUser(int id, [FromBody] MarketingUserDto marketingUserDto)
        {
            if (marketingUserDto == null)
            {
                return BadRequest("La información del usuario de marketing no puede ser nula");
            }

            try
            {
                var result = _marketingUserRepository.Update(id, marketingUserDto);
                return result;
            }
            catch (Exception ex)
            {
                await _slackNotifier.NotifyAsync(ex.Message);
                return StatusCode(500, $"Error al actualizar el usuario de marketing: {ex.Message}");
            }
        }
    }
}