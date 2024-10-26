namespace API.Helpers;

using API.DTOs;
using API.Entities;
using AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<AppUser, MemberResponse>();
        CreateMap<AppUser, PhotoResponse>();
    }
}