using Microsoft.AspNetCore.Mvc;
using Cupones.Models;
using Cupones.Services;

namespace Cupones.AddControllers
{
    [ApiController]

    [Route("api/couponhistories")]

    public class CouponHistoryController : ControllerBase
    {
        private readonly ICouponHistoryRepository _couponHistoryRepository;

        public CouponHistoryController(ICouponHistoryRepository couponHistoryRepository)
        {
            _couponHistoryRepository = couponHistoryRepository;
        }
        [HttpPost("{couponId}")]
        public IActionResult CreateCouponHistory(int couponId, [FromBody] CouponHistory couponHistory)
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
                return StatusCode(500, $"Error al crear el historial del cupón: {ex.Message}");
            }
        }
    }
    
}
