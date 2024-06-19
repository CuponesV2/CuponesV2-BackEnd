using Microsoft.AspNetCore.Mvc;
using Cupones.Dtos;
using Cupones.Services;
using Microsoft.AspNetCore.Authorization;

namespace Cupones.Controllers
{
    [ApiController]
    [Route("api/campaigns/update")]
    [Authorize]
    public class CampaignsUpdateController : ControllerBase
    {
        private readonly ICampaignRepository _campaignsRepository;
        private readonly SlackNotifier _slackNotifier;

        public CampaignsUpdateController(ICampaignRepository campaignRepository, SlackNotifier slackNotifier)
        {
            _campaignsRepository = campaignRepository;
            _slackNotifier = slackNotifier;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCampaign(int id, [FromBody] CampaignDto campaignDto)
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
                await _slackNotifier.NotifyAsync(ex.StackTrace);
                return StatusCode(500, $"Error al actualizar la campaña: {ex.Message}");
            }
        }
    }
}