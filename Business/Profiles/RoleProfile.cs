using AutoMapper;
using Business.Dtos.Requests.Role;
using Business.Dtos.Responses.Role;
using Entities.Concretes;

namespace Business.Profiles;

public class RoleProfile : Profile
{
    public RoleProfile()
    {
        CreateMap<Role, CreateRoleRequest>().ReverseMap();
        CreateMap<Role, CreatedRoleResponse>().ReverseMap();

        CreateMap<Role, UpdateRoleRequest>().ReverseMap();
        CreateMap<Role, UpdatedRoleResponse>().ReverseMap();

        CreateMap<Role, DeleteRoleRequest>().ReverseMap();
        CreateMap<Role, DeletedRoleResponse>().ReverseMap();

        CreateMap<Role, GetRoleResponse>().ReverseMap();

        CreateMap<Role, GetListRoleResponse>()
            .ReverseMap();
    }
}