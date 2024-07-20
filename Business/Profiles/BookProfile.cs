using AutoMapper;
using Business.Dtos.Requests.Book;
using Business.Dtos.Responses.Book;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<Book, CreateBookRequest>().ReverseMap();
        CreateMap<Book, CreatedBookResponse>().ReverseMap();

        CreateMap<Book, UpdateBookRequest>().ReverseMap();
        CreateMap<Book, UpdatedBookResponse>().ReverseMap();

        CreateMap<Book, DeleteBookRequest>().ReverseMap();
        CreateMap<Book, DeletedBookResponse>().ReverseMap();

        CreateMap<IPaginate<Book>, Paginate<GetListBookResponse>>().ReverseMap();
        CreateMap<Book, GetListBookResponse>().ReverseMap();

        CreateMap<Book, GetBookResponse>().ReverseMap();
    }
}