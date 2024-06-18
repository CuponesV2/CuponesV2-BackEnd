using Microsoft.EntityFrameworkCore;
using Cupones.Data;
using Cupones.Models;

namespace Cupones.Services
{
    public class CouponUsageRepository : ICouponUsageRepository
    {
        private readonly CuponesContext _context;

        public CouponUsageRepository(CuponesContext context)
        {
            _context = context;
        }

        public void RegisterCouponUsage(CouponUsage couponUsage)
        {
            couponUsage.Usage_date = DateOnly.Parse(DateTime.Now.ToString());
            _context.CouponUsages.Add(couponUsage);
            _context.SaveChanges();
        }
    }
}