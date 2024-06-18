using Microsoft.AspNetCore.Mvc;
using Cupones.Models;
using Cupones.Services;

namespace Cupones.AddControllers
{
    [ApiController]
    [Route("api/coupons")]

    public class Coupon : ControllerBase
    {
        private readonly ICouponRepository _couponRepository;

        public Coupon(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository;
        }

        [HttpGet]
        public IActionResult GetCoupons()
        {
            try
            {
                return Ok(_couponRepository.GetAll());

            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener los cupones: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCoupon(int id)
        {
            try
            {
                var coupon = _couponRepository.GetOne(id);

                if (coupon == null)
                {
                    return NotFound($"Cupón con id {id} no encontrado");
                }

                return Ok(coupon);
            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener el cupón con id {id}: {ex.Message}");
            }
        }
    }
}