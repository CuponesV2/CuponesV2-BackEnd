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
        private readonly SlackNotifier _slackNotifier;

        private readonly int records = 5;

        public MarketingUsersController(IMarketingUserRepository marketingUserRepository, SlackNotifier slackNotifier)
        {
            _marketingUserRepository = marketingUserRepository;
            _slackNotifier = slackNotifier;
        }

        [HttpGet]
        public IActionResult GetMarketingUsers([FromQuery]int? page)
        {
            try
            {
                return Ok(_marketingUserRepository.GetAll(page));
            }
            catch (Exception ex)
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
                return Ok(marketingUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener el usuario de marketing con id {id}: {ex.Message}");
            }
        }

        // Prueba con Slack
        [HttpPost]
        [Route("api/auth/sendmessage")]
        public async Task<IActionResult> SendMessageAsync([FromBody] string message)
        {
            try
            {
                throw new Exception("Probando con error controlado! ");
            }
            catch (Exception ex)
            {
                await _slackNotifier.NotifyAsync(message + ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al enviar el mensaje");
            }
        }
    }
}