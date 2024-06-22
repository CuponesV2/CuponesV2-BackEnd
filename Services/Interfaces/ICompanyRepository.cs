using Cupones.Models;
using Microsoft.AspNetCore.Mvc;
using Cupones.Dtos;

namespace Cupones.Services
{
    public interface ICompanyRepository
    {
        public object GetAll([FromQuery] int? page);
        
        public Company GetOne(int id);
        
        public void Create(Company company);

        public IActionResult Update(int id, [FromBody] CompanyDto companyDto);
    }
}