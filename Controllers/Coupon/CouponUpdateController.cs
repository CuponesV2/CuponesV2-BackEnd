using Microsoft.AspNetCore.Mvc;
using Cupones.Dtos;
using Cupones.Services;

namespace Cupones.Controllers
{
    [ApiController]
    [Route("api/coupons/update")]
    public class CouponUpdateController : ControllerBase
    {
        private readonly ICouponRepository _couponRepository;

        public CouponUpdateController(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCoupon(int id, [FromBody] CouponDto couponDto)
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
                return StatusCode(500, $"Error al actualizar el cupón: {ex.Message}");
            }
        }
    }
}