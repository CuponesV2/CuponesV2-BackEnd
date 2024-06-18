using Microsoft.AspNetCore.Mvc;
using Cupones.Models;
using Cupones.Services;

namespace Cupones.Controllers
{
    [ApiController]
    [Route("api/companies")]

    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;

        public CompaniesController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        [HttpGet]
        public IActionResult GetCompanies()
        {
            try
            {
                return Ok(_companyRepository.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener las empresas: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCompany(int id)
        {
            try
            {
                var company = _companyRepository.GetOne(id);

                if (company == null)
                {
                    return NotFound($"Empresa con id {id} no encontrado");
                }

                return Ok(company);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener la empresa con id {id}: {ex.Message}");
            }
        }
    }
}