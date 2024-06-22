using Microsoft.AspNetCore.Mvc;
using Cupones.Models;
using Cupones.Services;
using Microsoft.AspNetCore.Authorization;

namespace Cupones.Controllers
{
    [ApiController]
    [Route("api/coupons/usages")]
    [Authorize]

    public class CouponUsageController : ControllerBase 
    {
        private readonly ICouponUsageRepository _couponUsageRepository;
        private readonly SlackNotifier _slackNotifier;

        public CouponUsageController(ICouponUsageRepository couponUsageRepository, SlackNotifier slackNotifier) 
        {
            _couponUsageRepository = couponUsageRepository;
            _slackNotifier = slackNotifier;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCouponUsage(CouponUsage couponUsage) 
        {
            if (couponUsage == null)
            {
                return BadRequest("El uso del cupón no puede ser nulo");
            }
            try
            {
                _couponUsageRepository.RegisterCouponUsage(couponUsage);
                return Ok(couponUsage);
            }
            catch (Exception ex)
            {
                await _slackNotifier.NotifyAsync(ex.StackTrace);
                return StatusCode(500, $"Error al crear el uso del cupón: {ex.Message}");
            }
        }
    }
}