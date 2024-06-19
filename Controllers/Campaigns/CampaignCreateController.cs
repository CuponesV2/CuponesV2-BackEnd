using Microsoft.AspNetCore.Mvc;
using Cupones.Models;
using Cupones.Services;
using Microsoft.AspNetCore.Authorization;

namespace Cupones.Controllers
{
    [ApiController]
    [Route("api/campaigns/create")]
    [Authorize]
    
    public class CampaignsCreateController : ControllerBase
    {
        private readonly ICampaignRepository _campaignsRepository;
        private readonly SlackNotifier _slackNotifier;

        public CampaignsCreateController(ICampaignRepository campaignRepository, SlackNotifier slackNotifier)
        {
            _campaignsRepository = campaignRepository;
            _slackNotifier = slackNotifier;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCampaign(Campaign campaign)
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
                await _slackNotifier.NotifyAsync(ex.StackTrace);
                return StatusCode(500, $"Error al crear la campaña: {ex.Message}");
            }
        }
    }
}