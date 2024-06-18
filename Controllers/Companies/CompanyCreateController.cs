using Microsoft.AspNetCore.Mvc;
using Cupones.Models;
using Cupones.Services;

namespace Cupones.Controllers
{
    [ApiController]
    [Route("api/companies/create")]
    
    public class CompanyCreateController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyCreateController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        [HttpPost]
        public IActionResult CreateCompany(Company company)
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
                return StatusCode(500, $"Error al crear la empresa: {ex.Message}");
            }
        }
    }
}