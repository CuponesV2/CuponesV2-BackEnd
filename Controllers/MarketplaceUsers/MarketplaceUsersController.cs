using Microsoft.AspNetCore.Mvc;
using Cupones.Models;
using Cupones.Services;

namespace Cupones.AddControllers
{
    [ApiController]
    [Route("api/marketplaceUsers")]
    
    public class MarketplaceUsersController : ControllerBase
    {
        private readonly IMarketplaceUserRepository _marketplaceUserRepository;

        public MarketplaceUsersController(IMarketplaceUserRepository marketplaceUserRepository)
        {
            _marketplaceUserRepository = marketplaceUserRepository;
        }

        [HttpGet]
        public IActionResult GetMarketplaceUsers([FromQuery]int? page)
        {
            try
            {
                return Ok(_marketplaceUserRepository.GetAll(page));

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener los usuarios de marketplace: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetMarketplaceUser(int id)
        {
            try
            {
                var marketplaceUser = _marketplaceUserRepository.GetOne(id);

                if (marketplaceUser == null)
                {
                    return NotFound($"Usuario de marketplace con id {id} no encontrado");
                }

                return Ok(marketplaceUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener el usuario de marketplace con id {id}: {ex.Message}");
            }
        }
    }
}