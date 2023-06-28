using CitationParser.Core.Dto;
using CitationParser.Core.Model.Auth;
using AutoMapper;
using CitationParser.Api.Dto.Role;
using CitationParser.Api.Dto.User;
using CitationParser.Core.Extensions;

namespace CitationParser.Api.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, AuthResponseDto>()
            .ForMember(
                dest => dest.Roles,
                opt =>
                    opt.MapFrom(u => u.UserRoles.Select(r => r.Id)));

        CreateMap<UserRequestDto, User>()
            .ForMember(dest => dest.PasswordHash,
                opt => opt.MapFrom(x => x.Password.Hash()));

        CreateMap<User, UserResponseDto>();
        CreateMap<Role, RoleResponseDto>();
        CreateMap<RoleRequestDto, Role>();
    }
}