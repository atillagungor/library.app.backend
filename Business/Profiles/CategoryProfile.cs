using AutoMapper;
using Business.Dtos.Requests.Category;
using Business.Dtos.Responses.Category;
using Entities.Concretes;

namespace Business.Profiles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CreateCategoryRequest>().ReverseMap();
        CreateMap<Category, CreatedCategoryResponse>().ReverseMap();

        CreateMap<Category, UpdateCategoryRequest>().ReverseMap();
        CreateMap<Category, UpdatedCategoryResponse>().ReverseMap();

        CreateMap<Category, DeleteCategoryRequest>().ReverseMap();
        CreateMap<Category, DeletedCategoryResponse>().ReverseMap();

        CreateMap<Category, GetCategoryResponse>()
            .ForMember(dest => dest.BookIds, opt => opt.MapFrom(src => src.Books.Select(b => b.Id).ToList()))
            .ReverseMap();

        CreateMap<Category, GetListCategoryResponse>()
            .ForMember(dest => dest.BookIds, opt => opt.MapFrom(src => src.Books.Select(b => b.Id).ToList()))
            .ReverseMap();
    }
}