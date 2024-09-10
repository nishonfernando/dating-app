using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;

namespace API.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<AppUser, MemberDto>()
            .ForMember(
                destination => destination.PhotoUrl, option => option.MapFrom(source => source.Photos.FirstOrDefault(x => x.IsMain)!.Url)
            )
            .ForMember(d => d.Age, o => o.MapFrom(s => s.DateOfBirth.CalculateAge()));
        CreateMap<Photo, PhotoDto>();
        CreateMap<MemberUpdateDto, AppUser>();
        CreateMap<RegisterDto, AppUser>();

        CreateMap<string, DateOnly>().ConvertUsing(s => DateOnly.Parse(s));
    }
}
