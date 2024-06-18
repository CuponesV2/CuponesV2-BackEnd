using AutoMapper;
using Cupones.Dtos;
using Cupones.Models;

public class MarketingUpdateProfile : Profile
{
    public MarketingUpdateProfile()
    {
        CreateMap<MarketingUserDto, MarketingUser>()
        .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
}