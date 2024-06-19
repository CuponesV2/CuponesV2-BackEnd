using Microsoft.AspNetCore.Mvc;
using Cupones.Models;
using Cupones.Services;

namespace Cupones.Controllers
{
    [ApiController]
    [Route("api/coupons/usages")]

    public class CouponUsageController : ControllerBase 
    {
        private readonly ICouponUsageRepository _couponUsageRepository;

        public CouponUsageController(ICouponUsageRepository couponUsageRepository) 
        {
            _couponUsageRepository = couponUsageRepository;
        }

        [HttpPost]
        public IActionResult CreateCouponUsage(CouponUsage couponUsage) 
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
                return StatusCode(500, $"Error al crear el uso del cupón: {ex.Message}");
            }
        }
    }
}