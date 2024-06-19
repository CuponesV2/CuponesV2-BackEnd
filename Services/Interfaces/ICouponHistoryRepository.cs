using Cupones.Models;
using Microsoft.AspNetCore.Mvc;
using Cupones.Dtos;

namespace Cupones.Services
{
    public interface ICouponHistoryRepository
    {
        public void Create(int coupon_id, CouponHistory couponHistory);
        
    }
}