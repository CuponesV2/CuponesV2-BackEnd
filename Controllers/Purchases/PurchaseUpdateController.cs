using Microsoft.AspNetCore.Mvc;
using Cupones.Services;
using Cupones.Dtos;

namespace Cupones.AddControllers
{
    [ApiController]
    [Route("api/purchases/update")]
    
    public class PurchaseUpdateController : ControllerBase
    {
        private readonly IPurchaseRepository _purchaseRepository;

        public PurchaseUpdateController(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePurchase(int id, [FromBody] PurchaseDto purchaseDto)
        {
            if (purchaseDto == null)
            {
                return BadRequest("La información de la compra no puede ser nula");
            }

            try
            {
                var result = _purchaseRepository.Update(id, purchaseDto);
                return result;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar la compra: {ex.Message}");
            }
        }
    }
}