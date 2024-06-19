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

    private readonly int records = 5;

    public CompanyRepository(CuponesContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public object GetAll([FromQuery] int? page)
    {
        int _page = page ?? 1;
            decimal totalRecords = _context.Companies.Count();
            int totalPages = Convert.ToInt32(Math.Ceiling(totalRecords / records));
            
            var companies = _context.Companies
                .Skip((_page - 1) * records)
                .Take(records)
                .ToList();
        
            var data = new { pages = totalPages,
                            currentPage = _page,
                            data = companies};
            
            return data;
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