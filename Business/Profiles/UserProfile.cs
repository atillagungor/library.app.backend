using AutoMapper;
using Business.Dtos.Requests.User;
using Business.Dtos.Responses.User;
using Entities.Concretes;

namespace Business.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, CreateUserRequest>().ReverseMap();
        CreateMap<User, CreatedUserResponse>().ReverseMap();

        CreateMap<User, UpdateUserRequest>().ReverseMap();
        CreateMap<User, UpdatedUserResponse>().ReverseMap();

        CreateMap<User, DeleteUserRequest>().ReverseMap();
        CreateMap<User, DeletedUserResponse>().ReverseMap();

        CreateMap<User, GetUserResponse>()
            .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name))
            .ReverseMap();

        CreateMap<User, GetListUserResponse>()
            .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name))
            .ReverseMap();
    }
}