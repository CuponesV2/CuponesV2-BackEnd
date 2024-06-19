using Microsoft.AspNetCore.Mvc;
using Cupones.Dtos;
using Cupones.Services;
using Microsoft.AspNetCore.Authorization;

namespace Cupones.Controllers
{
    [ApiController]
    [Route("api/coupons/update")]
    [Authorize]
    public class CouponUpdateController : ControllerBase
    {
        private readonly ICouponRepository _couponRepository;
        private readonly SlackNotifier _slackNotifier;

        public CouponUpdateController(ICouponRepository couponRepository, SlackNotifier slackNotifier)
        {
            _couponRepository = couponRepository;
            _slackNotifier = slackNotifier;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCoupon(int id, [FromBody] CouponDto couponDto)
        {
            if (couponDto == null)
            {
                return BadRequest("La información del cupón no puede ser nula");
            }
            try
            {
                var result = _couponRepository.Update(id, couponDto);
                return result;
            }
            catch (Exception ex)
            {
                await _slackNotifier.NotifyAsync(ex.StackTrace);
                return StatusCode(500, $"Error al actualizar el cupón: {ex.Message}");
            }
        }
    }
}