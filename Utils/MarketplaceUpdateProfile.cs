using AutoMapper;
using Cupones.Dtos;
using Cupones.Models;

namespace Cupones.Utils
{
public class MarketplaceUpdateProfile : Profile
{
    public MarketplaceUpdateProfile()
    {
        CreateMap<MarketplaceUserDto, MarketplaceUser>()
        .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
}
}