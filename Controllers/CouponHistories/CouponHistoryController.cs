using Microsoft.AspNetCore.Mvc;
using Cupones.Models;
using Cupones.Services;
using Microsoft.AspNetCore.Authorization;

namespace Cupones.AddControllers
{
    [ApiController]
    [Route("api/couponhistories")]
    [Authorize]

    public class CouponHistoryController : ControllerBase
    {
        private readonly ICouponHistoryRepository _couponHistoryRepository;
        private readonly SlackNotifier _slackNotifier;

        public CouponHistoryController(ICouponHistoryRepository couponHistoryRepository, SlackNotifier slackNotifier)
        {
            _couponHistoryRepository = couponHistoryRepository;
            _slackNotifier = slackNotifier;
        }
        [HttpPost("{couponId}")]
        public async Task<IActionResult> CreateCouponHistory(int couponId, [FromBody] CouponHistory couponHistory)
        {
            if (couponHistory == null)
            {
                return BadRequest("El historial del cupón no puede ser nulo");
            }
            try
            {
                _couponHistoryRepository.Create(couponId, couponHistory);
                return Ok(couponHistory);
                
            } catch (Exception ex)
            {
                await _slackNotifier.NotifyAsync(ex.StackTrace);
                return StatusCode(500, $"Error al crear el historial del cupón: {ex.Message}");
            }
        }
    }
    
}
