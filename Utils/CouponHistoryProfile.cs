using AutoMapper;
using Cupones.Dtos;
using Cupones.Models;


namespace Cupones.Utils
{
    public class CouponHistoryProfile : Profile
    {
        public CouponHistoryProfile()
        {
            CreateMap<CouponHistoryDto, CouponHistory>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}

