using Microsoft.AspNetCore.Mvc;
using Cupones.Dtos;
using Cupones.Services;
using Microsoft.AspNetCore.Authorization;

namespace Cupones.Controllers
{
    [ApiController]
    [Route("api/companies/update")]
    [Authorize]
    public class CompanyUpdateController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly SlackNotifier _slackNotifier;

        public CompanyUpdateController(ICompanyRepository companyRepository, SlackNotifier slackNotifier)
        {
            _companyRepository = companyRepository;
            _slackNotifier = slackNotifier;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany(int id, [FromBody] CompanyDto companyDto)
        {
            if (companyDto == null)
            {
                return BadRequest("La información de la empresa no puede ser nula");
            }
            try
            {
                var result = _companyRepository.Update(id, companyDto);
                return result;
            }
            catch (Exception ex)
            {
                await _slackNotifier.NotifyAsync(ex.StackTrace);
                return StatusCode(500, $"Error al actualizar la empresa: {ex.Message}");
            }
        }
    }
}