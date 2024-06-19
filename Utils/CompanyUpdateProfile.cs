using AutoMapper;
using Cupones.Models;
using Cupones.Dtos;

public class CompanyUpdateProfile : Profile
{
    public CompanyUpdateProfile()
    {
        CreateMap<CompanyDto, Company>()
       .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember!= null));
    }
}