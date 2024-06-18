using Cupones.Models;
using Microsoft.AspNetCore.Mvc;
using Cupones.Dtos;

namespace Cupones.Services
{
    public interface ICouponHistoryRepository
    {
        public void Create(int couponId, CouponHistory couponHistory);
        
    }
}