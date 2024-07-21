using AutoMapper;
using Business.Dtos.Requests.Admin;
using Business.Dtos.Responses.Admin;
using Entities.Concretes;

namespace Business.Profiles;

public class AdminProfile : Profile
{
    public AdminProfile()
    {
        CreateMap<Admin, CreateAdminRequest>().ReverseMap();
        CreateMap<Admin, CreatedAdminResponse>().ReverseMap();

        CreateMap<Admin, UpdateAdminRequest>().ReverseMap();
        CreateMap<Admin, UpdatedAdminResponse>().ReverseMap();

        CreateMap<Admin, DeleteAdminRequest>().ReverseMap();
        CreateMap<Admin, DeletedAdminResponse>().ReverseMap();

        CreateMap<Admin, GetAdminResponse>().ReverseMap();

        CreateMap<Admin, GetListAdminResponse>()
            .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.RoleId))
            .ReverseMap();
    }
}