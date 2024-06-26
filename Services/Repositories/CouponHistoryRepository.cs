using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Cupones.Data;
using Cupones.Models;
using Cupones.Dtos;

namespace Cupones.Services
{
    public class CouponHistoryRepository : ICouponHistoryRepository
    {
        private readonly CuponesContext _context;
        private readonly IMapper _mapper;

        public CouponHistoryRepository(CuponesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

public void CreateHistory(int couponId, CouponHistoryDto couponHistoryDto)
{
    var coupon = _context.Coupons.Find(couponId);
    if (coupon == null)
    {
        throw new Exception("Cupón no encontrado.");
    }

    var couponHistory = _mapper.Map<CouponHistory>(couponHistoryDto);
    couponHistory.Change_date = DateOnly.FromDateTime(DateTime.Now);

    switch (couponHistory.Field_changed)
    {
        case "Name":
            couponHistory.Old_value = coupon.Name;
            break;
        case "Description":
            couponHistory.Old_value = coupon.Description;
            break;
        case "Start_date":
            couponHistory.Old_value = coupon.Start_date.ToString();
            break;
        case "End_date":
            couponHistory.Old_value = coupon.End_date.ToString();
            break;
        default:
            throw new Exception("Campo a cambiar no reconocido.");
    }

    couponHistory.CouponId = couponId;

    _context.CouponHistories.Add(couponHistory);
    _context.SaveChanges();
}
    }
}

