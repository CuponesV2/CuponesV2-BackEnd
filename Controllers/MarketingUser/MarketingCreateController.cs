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

        public MarketingCreateController(IMarketingUserRepository marketingUserRepository)
        {
            _marketingUserRepository = marketingUserRepository;
        }

        [HttpPost]
        public IActionResult CreateMarketingUser(MarketingUser marketingUser)
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
                return StatusCode(500, $"Error al crear el usuario de marketing: {ex.Message}");
            }
        }
    }
}