using Microsoft.AspNetCore.Mvc;
using Cupones.Models;
using Cupones.Services;
using Microsoft.AspNetCore.Authorization;

namespace Cupones.Controllers
{
    [ApiController]
    [Route("api/companies/create")]
    [Authorize]
    
    public class CompanyCreateController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly SlackNotifier _slackNotifier;

        public CompanyCreateController(ICompanyRepository companyRepository, SlackNotifier slackNotifier)
        {
            _companyRepository = companyRepository;
            _slackNotifier = slackNotifier;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(Company company)
        {
            if (company == null)
            {
                return BadRequest("La empresa no puede ser nula");
            }
            try
            {
                _companyRepository.Create(company);
                return Ok(company);

            } catch (Exception ex)
            {
                await _slackNotifier.NotifyAsync(ex.StackTrace);
                return StatusCode(500, $"Error al crear la empresa: {ex.Message}");
            }
        }
    }
}