using Microsoft.AspNetCore.Mvc;
using Cupones.Models;
using Cupones.Services;
using Microsoft.AspNetCore.Authorization;

namespace Cupones.AddControllers
{
    [ApiController]
    [Route("api/coupons/create")]
    [Authorize]
    public class CouponCreateController : ControllerBase
    {
        private readonly ICouponRepository _couponRepository;
        private readonly SlackNotifier _slackNotifier;

        public CouponCreateController(ICouponRepository couponRepository, SlackNotifier slackNotifier)
        {
            _couponRepository = couponRepository;
            _slackNotifier = slackNotifier;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCoupon(Coupon coupon)
        {
            if (coupon == null)
            {
                return BadRequest("El cupón no puede ser nulo");
            }
            try
            {
                _couponRepository.Create(coupon);
                return Ok(coupon);
            } catch (Exception ex)
            {
                await _slackNotifier.NotifyAsync(ex.StackTrace);
                return StatusCode(500, $"Error al crear el cupón: {ex.Message}");
            }
        }
    }
}