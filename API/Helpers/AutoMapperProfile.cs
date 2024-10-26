namespace API.Helpers;

using API.DTOs;
using API.Entities;
using AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<AppUser, MemberResponse>()
            .ForMember(
                d => d.PhotoUrl,
                o => o.MapFrom(
                    s => s.Photos.FirstOrDefault(p => p.IsMain)!.Url));
        CreateMap<AppUser, PhotoResponse>();
    }
}