using Microsoft.EntityFrameworkCore;
using Cupones.Data;
using Cupones.Models;
using AutoMapper;
using Cupones.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Cupones.Services
{
    public class MarketingUserRepository : IMarketingUserRepository
    {
        private readonly CuponesContext _context;
        private readonly IMapper _mapper;

        public MarketingUserRepository(CuponesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<MarketingUser> GetAll()
        {
            return _context.MarketingUsers.ToList();
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

