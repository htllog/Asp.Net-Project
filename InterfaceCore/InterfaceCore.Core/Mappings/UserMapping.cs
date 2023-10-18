using AutoMapper;
using InterfaceCore.Core.Domain;
using InterfaceCore.Message.Dto;

namespace InterfaceCore.Core.Mappings;

public class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<GetUserDto, User>();
        CreateMap<User, GetUserDto>();
    }
}