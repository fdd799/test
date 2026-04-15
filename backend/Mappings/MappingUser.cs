namespace backend.Mappings;

using AutoMapper;
using backend.DTOS.Users;
using backend.Entities;

public class MappingUser : Profile
{
    public MappingUser()
    {
        CreateMap<CreateUserDto, UsersEntity>();
        CreateMap<UsersResponseDto, UsersEntity>();
        CreateMap<UsersEntity, UsersResponseDto>();
    }
}