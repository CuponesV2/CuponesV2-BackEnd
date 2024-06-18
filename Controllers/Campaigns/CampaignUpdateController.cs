using Microsoft.AspNetCore.Mvc;
using Cupones.Dtos;
using Cupones.Services;

namespace Cupones.Controllers
{
    [ApiController]
    [Route("api/campaigns/update")]
    public class CampaignsUpdateController : ControllerBase
    {
        private readonly ICampaignRepository _campaignsRepository;

        public CampaignsUpdateController(ICampaignRepository campaignRepository)
        {
            _campaignsRepository = campaignRepository;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCampaign(int id, [FromBody] CampaignDto campaignDto)
        {
            if (campaignDto == null)
            {
                return BadRequest("La información de la campaña no puede ser nula");
            }

            try
            {
                var result = _campaignsRepository.Update(id, campaignDto);
                return result;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar la campaña: {ex.Message}");
            }
        }
    }
}