using Microsoft.EntityFrameworkCore;
using Cupones.Data;
using Cupones.Models;
using AutoMapper;
using Cupones.Dtos;
using Microsoft.AspNetCore.Mvc;


namespace Cupones.Services
{
    public class CouponRepository : ICouponRepository
    {
        private readonly CuponesContext _context;
        private readonly IMapper _mapper;

        public CouponRepository(CuponesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Coupon> GetAll()
        {
            return _context.Coupons.ToList();
        }

        public Coupon GetOne(int id)
        {
            return _context.Coupons.FirstOrDefault(u => u.Id == id);
        }

        public void Create(Coupon coupon)
        {
            _context.Coupons.Add(coupon);
            _context.SaveChanges();
        }
        
        public IActionResult Update(int id, CouponDto couponDto)
        {
            var coupon = _context.Coupons.Find(id);
            if (coupon == null)
            {
                return new NotFoundResult();
            }
            _mapper.Map(couponDto, coupon);
            _context.SaveChanges();
            
            return new OkObjectResult(coupon);
        }
    }

}

