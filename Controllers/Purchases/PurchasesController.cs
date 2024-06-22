using Microsoft.AspNetCore.Mvc;
using Cupones.Models;
using Cupones.Services;

namespace Cupones.AddControllers
{
    [ApiController]
    [Route("api/purchases")]
    
    public class PurchasesController : ControllerBase
    {
        private readonly IPurchaseRepository _purchaseRepository;

        public PurchasesController(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        [HttpGet]
        public IActionResult GetMarketingUsers()
        {
            try
            {
                return Ok(_purchaseRepository.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener las compras: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult Purchase(int id)
        {
            try
            {
                var purchase = _purchaseRepository.GetOne(id);
                if (purchase == null)
                {
                    return NotFound($"La compra con id {id} no encontrado");
                }
                return Ok(purchase);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener la compra con id {id}: {ex.Message}");
            }
        }
    }
}