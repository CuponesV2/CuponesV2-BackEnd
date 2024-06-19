using AutoMapper;
using Cupones.Dtos;
using Cupones.Models;

namespace Cupones.Utils
{
    public class MarketingUpdateProfile : Profile
{
    public MarketingUpdateProfile()
    {
        CreateMap<MarketingUserDto, MarketingUser>()
        .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
}
}
