using AutoMapper;
using Cupones.Models;
using Cupones.Dtos;

public class CampaignUpdateProfile : Profile
{
    public CampaignUpdateProfile()
    {
        CreateMap<CampaignDto, Campaign>()
        .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember!= null));
    }
}