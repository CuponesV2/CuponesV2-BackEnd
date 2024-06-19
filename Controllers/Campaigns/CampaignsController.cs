using Microsoft.AspNetCore.Mvc;
using Cupones.Models;
using Cupones.Services;

namespace Cupones.Controllers
{
    [ApiController]
    [Route("api/campaigns")]

    public class CampaignsController : ControllerBase
    {
        private readonly ICampaignRepository _campaignRepository;

        public CampaignsController(ICampaignRepository campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }

        [HttpGet]
        public object GetCampaigns([FromQuery] int? page)
        {
            try
            {
                return Ok(_campaignRepository.GetAll(page));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener las campañas: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCampaign(int id)
        {
            try
            {
                var campaign = _campaignRepository.GetOne(id);

                if (campaign == null)
                {
                    return NotFound($"Campaña con id {id} no encontrado");
                }

                return Ok(campaign);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener la campaña con id {id}: {ex.Message}");
            }
        }
    }
}