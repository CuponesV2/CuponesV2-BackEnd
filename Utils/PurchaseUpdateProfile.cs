using AutoMapper;
using Cupones.Models;
using Cupones.Dtos;

public class PurchaseUpdateProfile : Profile
{
    public PurchaseUpdateProfile()
    {
        CreateMap<PurchaseDto, Purchase>()
        .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
}