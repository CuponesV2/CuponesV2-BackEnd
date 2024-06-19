using Microsoft.EntityFrameworkCore;
using Cupones.Data;
using Cupones.Models;
using Microsoft.AspNetCore.Mvc;
using Cupones.Dtos;
using AutoMapper;

namespace Cupones.Services;

public class CompanyRepository : ICompanyRepository
{
    private readonly CuponesContext _context;

    private readonly IMapper _mapper;

    public CompanyRepository(CuponesContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<Company> GetAll()
    {
        return _context.Companies.ToList();
    }

    public Company GetOne(int id)
    {
        return _context.Companies.Find(id);
    }

    public void Create(Company company)
    {
        _context.Companies.Add(company);
        _context.SaveChanges();
    }

    public IActionResult Update(int id, CompanyDto companyDto)
    {
        var company = _context.Companies.Find(id);
        if (company == null)
        {
            return new NotFoundResult();
        }
        _mapper.Map(companyDto, company);
        _context.SaveChanges();

        return new OkObjectResult(company);
    }
}