using Microsoft.AspNetCore.Mvc;
using Cupones.Dtos;
using Cupones.Services;

namespace Cupones.Controllers
{
    [ApiController]
    [Route("api/companies/update")]
    public class CompanyUpdateController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyUpdateController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCompany(int id, [FromBody] CompanyDto companyDto)
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
                return StatusCode(500, $"Error al actualizar la empresa: {ex.Message}");
            }
        }
    }
}