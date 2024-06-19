using Microsoft.AspNetCore.Mvc;
using Cupones.Models;
using Cupones.Services;

namespace Cupones.AddControllers
{
    [ApiController]
    [Route("api/marketingusers")]
    
    public class MarketingUsersController : ControllerBase
    {
        private readonly IMarketingUserRepository _marketingUserRepository;

        private readonly IMailerSendRepository _mailerSendRepository;

        public MarketingUsersController(IMarketingUserRepository marketingUserRepository, IMailerSendRepository mailerSendRepository)
        {
            _marketingUserRepository = marketingUserRepository;
            _mailerSendRepository = mailerSendRepository;
        }

        [HttpGet]
        public IActionResult GetMarketingUsers()
        {
            try
            {
                return Ok(_marketingUserRepository.GetAll());

            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener los usuarios de marketing: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetMarketingUser(int id)
        {
            try
            {
                var marketingUser = _marketingUserRepository.GetOne(id);

                if (marketingUser == null)
                {
                    return NotFound($"Usuario de marketing con id {id} no encontrado");
                }
                
                _mailerSendRepository.SendMail(marketingUser.Email, marketingUser.Username);
                return Ok(marketingUser);
            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener el usuario de marketing con id {id}: {ex.Message}");
            }
        }
    }
}