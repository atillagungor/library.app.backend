using AutoMapper;
using Business.Dtos.Requests.Author;
using Business.Dtos.Responses.Author;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, CreateAuthorRequest>().ReverseMap();
            CreateMap<Author, CreatedAuthorResponse>().ReverseMap();

            CreateMap<Author, UpdateAuthorRequest>().ReverseMap();
            CreateMap<Author, UpdatedAuthorResponse>().ReverseMap();

            CreateMap<Author, DeleteAuthorRequest>().ReverseMap();
            CreateMap<Author, DeletedAuthorResponse>().ReverseMap();

            CreateMap<IPaginate<Author>, Paginate<GetListAuthorResponse>>().ReverseMap();
            CreateMap<Author, GetListAuthorResponse>().ReverseMap();

            CreateMap<Author, GetAuthorResponse>().ReverseMap();
        }
    }
}