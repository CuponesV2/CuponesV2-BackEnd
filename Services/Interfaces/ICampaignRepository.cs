using Cupones.Models;
using Microsoft.AspNetCore.Mvc;
using Cupones.Dtos;

namespace Cupones.Services
{
    public interface ICampaignRepository
    {
        public object GetAll([FromQuery] int? page);
        
        public Campaign GetOne(int id);
        
        public void Create(Campaign campaign);

        public IActionResult Update(int id, [FromBody] CampaignDto campaignDto);
    }
}