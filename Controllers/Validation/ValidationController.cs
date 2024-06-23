using Microsoft.AspNetCore.Mvc;
using Cupones.Models;
using Cupones.Services;

namespace Cupones.AddControllers
{
    [ApiController]
    [Route("api/validation")]
    
    public class ValidationController : ControllerBase
    {
        private readonly ICouponRepository _couponRepository;
        private readonly IPurchaseCouponRepository _purchaseCouponRepository;

        public ValidationController(ICouponRepository couponRepository, IPurchaseCouponRepository purchaseCouponRepository)
        {
            _couponRepository = couponRepository;
            _purchaseCouponRepository = purchaseCouponRepository;
        }

        [HttpGet("{id}")]
        public IActionResult ValidateCoupon(int id)
        {
            // Obtener cupón
            var coupon = _couponRepository.GetOne(id);

            // Obtener compras con este cupón
            var purchases = _purchaseCouponRepository.GetPurchasesByCoupon(id).Count();
            Console.WriteLine($"Compras con el cupón {coupon.Name}: {purchases}");

            // Verificación si no existe
            if (coupon == null)
            {
                return NotFound($"Cupón con id {id} no fue encontrado");
            }

            // Verificación si está Activo
            if (coupon.Status != "Activo")
            {
                return BadRequest($"El cupón {coupon.Name} está inactivo y no puede redimirse");
            }

            // Verificación si ha alcanzado el límite de usos
            if (purchases >= coupon.Usage_limit)
            {
                return BadRequest($"El cupón {coupon.Name} ha alcanzado su límite de usos y no puede redimirse");
            }

            // Verificación si ha expirado
            if (coupon.End_date < DateOnly.FromDateTime(DateTime.Now))
            {
                return BadRequest($"El cupón {coupon.Name} ha expirado y no puede redimirse");
            }
            
            return Ok(new { message = $"El cupón {coupon.Name} es válido y puede redimirse", coupon });
        }
    }
}