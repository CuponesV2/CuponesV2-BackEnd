using Microsoft.AspNetCore.Mvc;
using Cupones.Dtos;
using Cupones.Services;

namespace Cupones.Controllers
{
    [ApiController]
    [Route("api/marketingusers/update")]
    public class MarketingUpdateController : ControllerBase
    {
        private readonly IMarketingUserRepository _marketingUserRepository;

        public MarketingUpdateController(IMarketingUserRepository marketingUserRepository)
        {
            _marketingUserRepository = marketingUserRepository;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMarketingUser(int id, [FromBody] MarketingUserDto marketingUserDto)
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
                return StatusCode(500, $"Error al actualizar el usuario de marketing: {ex.Message}");
            }
        }
    }
}