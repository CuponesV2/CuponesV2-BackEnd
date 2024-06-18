using Microsoft.AspNetCore.Mvc;
using Cupones.Models;
using Cupones.Services;

namespace Cupones.AddControllers
{
    [ApiController]
    [Route("api/coupons/create")]
    public class CouponCreateController : ControllerBase
    {
        private readonly ICouponRepository _couponRepository;

        public CouponCreateController(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository;
        }
        [HttpPost]
        public IActionResult CreateCoupon(Coupon coupon)
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
                return StatusCode(500, $"Error al crear el cupón: {ex.Message}");
            }
        }
    }
}