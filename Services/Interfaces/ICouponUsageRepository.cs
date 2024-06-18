using Cupones.Models;

namespace Cupones.Services
{
    public interface ICouponUsageRepository
    {
        void RegisterCouponUsage(CouponUsage couponUsage);
    }
}