using AutoMapper;
using Cupones.Dtos;
using Cupones.Models;

public class MarketingUpdateProfile : Profile
{
    public MarketingUpdateProfile()
    {
        CreateMap<MarketingUser, MarketingUserDto>()
        .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
}