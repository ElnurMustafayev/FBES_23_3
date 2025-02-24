namespace Cqrs.WebApi.Mappers;

using AutoMapper;
using Cqrs.WebApi.Dtos;
using Cqrs.WebApi.Models;

public class UserCreateRequestDto_User_Mapper : Profile
{
    public UserCreateRequestDto_User_Mapper()
    {
        base.CreateMap<UserCreateRequestDto, User>()
            .ForMember(dest => dest.Firstname, config => config.MapFrom(src => src.Name.ToLower()))
            .ForMember(dest => dest.Lastname, config => config.MapFrom(src => src.Surname.ToLower()));
    }
}