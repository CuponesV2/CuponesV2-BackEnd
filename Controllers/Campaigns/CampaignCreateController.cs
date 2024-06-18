using Microsoft.AspNetCore.Mvc;
using Cupones.Models;
using Cupones.Services;

namespace Cupones.Controllers
{
    [ApiController]
    [Route("api/campaigns/create")]
    
    public class CampaignsCreateController : ControllerBase
    {
        private readonly ICampaignRepository _campaignsRepository;

        public CampaignsCreateController(ICampaignRepository campaignRepository)
        {
            _campaignsRepository = campaignRepository;
        }

        [HttpPost]
        public IActionResult CreateCampaign(Campaign campaign)
        {
            if (campaign == null)
            {
                return BadRequest("La campaña no puede ser nula");
            }
            try
            {
                _campaignsRepository.Create(campaign);
                return Ok(campaign);

            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear la campaña: {ex.Message}");
            }
        }
    }
}