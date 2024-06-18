using Microsoft.AspNetCore.Mvc;
using Cupones.Models;
using Cupones.Services;

namespace Cupones.AddControllers
{
    [ApiController]
    [Route("api/purchases")]
    
    public class PurchaseCreateController : ControllerBase
    {
        private readonly IPurchaseRepository _purchaseRepository;

        public PurchaseCreateController(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        [HttpPost]
        public IActionResult CreatePurchase(Purchase purchase)
        {
            try
            {
                _purchaseRepository.Create(purchase);
                return Ok(purchase);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear la compra: {ex.Message}");
            }
        }
    }
}