using Microsoft.AspNetCore.Mvc;
using Cupones.Models;
using Cupones.Services;
using Microsoft.AspNetCore.Authorization;

namespace Cupones.AddControllers
{
    [ApiController]
    [Route("api/marketingusers/create")]
    [Authorize]
    
    public class MarketingCreateController : ControllerBase
    {
        private readonly IMarketingUserRepository _marketingUserRepository;
        private readonly SlackNotifier _slackNotifier;

        public MarketingCreateController(IMarketingUserRepository marketingUserRepository, SlackNotifier slackNotifier)
        {
            _marketingUserRepository = marketingUserRepository;
            _slackNotifier = slackNotifier;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMarketingUser(MarketingUser marketingUser)
        {
            if (marketingUser == null)
            {
                return BadRequest("El usuario de marketing no puede ser nulo");
            }
            try
            {
                _marketingUserRepository.Create(marketingUser);
                return Ok(marketingUser);

            } catch (Exception ex)
            {
                await _slackNotifier.NotifyAsync(ex.StackTrace);
                return StatusCode(500, $"Error al crear el usuario de marketing: {ex.Message}");
            }
        }
    }
}