using Microsoft.EntityFrameworkCore;
using Cupones.Data;
using Cupones.Models;
using AutoMapper;
using Cupones.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Cupones.Services
{
    public class MarketingUserRepository : IMarketingUserRepository
    {
        private readonly CuponesContext _context;
        private readonly IMapper _mapper;

        private readonly int records = 5;

        public MarketingUserRepository(CuponesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public object GetAll([FromQuery] int? page)
        {
            int _page = page ?? 1;
            decimal totalRecords = _context.MarketingUsers.Count();
            int totalPages = Convert.ToInt32(Math.Ceiling(totalRecords / records));
            
            var marketingUsers = _context.MarketingUsers
                .Skip((_page - 1) * records)
                .Take(records)
                .ToList();
        
            var data = new { pages = totalPages,
                            currentPage = _page,
                            data = marketingUsers};
            
            return data;
        }

        public int Count()
        {
            return _context.MarketingUsers.Count();
        }

        public MarketingUser GetOne(int id)
        {
            return _context.MarketingUsers.Find(id);
        }

        public void Create(MarketingUser marketingUser)
        {
            _context.MarketingUsers.Add(marketingUser);
            _context.SaveChanges();
        }
        
        public IActionResult Update(int id, MarketingUserDto marketingUserDto)
        {
            var marketingUser = _context.MarketingUsers.Find(id);
            if (marketingUser == null)
            {
                return new NotFoundResult();
            }
            _mapper.Map(marketingUserDto, marketingUser);
            _context.SaveChanges();
            
            return new OkObjectResult(marketingUser);
        }
    }
}

