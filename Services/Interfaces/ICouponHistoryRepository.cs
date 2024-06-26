using Cupones.Dtos;

namespace Cupones.Services
{
    public interface ICouponHistoryRepository
    {
        void CreateHistory(int couponId, CouponHistoryDto couponHistoryDto);
    }
}
