using AutoMapper;
using Cupones.Dtos;
using Cupones.Models;


namespace Cupones.Utils
{
    public class CouponUpdateProfile : Profile
    {
        public CouponUpdateProfile()
        {
            CreateMap<CouponDto, Coupon>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}