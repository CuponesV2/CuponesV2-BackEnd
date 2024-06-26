using Cupones.Models;
using Microsoft.AspNetCore.Mvc;
using Cupones.Dtos;

namespace Cupones.Services
{
    public interface ICouponRepository
    {
        public IEnumerable<Coupon> GetAll();

        public Coupon GetOne(int id);

        public void Create(Coupon coupon);

        public IActionResult Update(int id, [FromBody] CouponDto couponDto);

    }
}