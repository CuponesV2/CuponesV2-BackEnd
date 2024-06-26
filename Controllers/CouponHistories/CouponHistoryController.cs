using Cupones.Dtos;
using Cupones.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cupones.Controllers
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
        public async Task<IActionResult> CreateCouponHistory(int couponId, [FromBody] CouponHistoryDto couponHistoryDto)
        {
            if (couponHistoryDto == null)
            {
                return BadRequest("El historial del cupón no puede ser nulo");
            }
            try
            {
                _couponHistoryRepository.CreateHistory(couponId, couponHistoryDto);
                return Ok(couponHistoryDto);
            }
            catch (Exception ex)
            {
                await _slackNotifier.NotifyAsync(ex.StackTrace);
                return StatusCode(500, $"Error al crear el historial del cupón: {ex.Message}");
            }
        }
    }
}