using Business.Dtos.Requests.Book;
using Business.Dtos.Responses.Book;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IBookService
{
    Task<CreatedBookResponse> AddAsync(CreateBookRequest createBookRequest);
    Task<IPaginate<GetListBookResponse>> GetListAsync(PageRequest pageRequest);
    Task<DeletedBookResponse> DeleteByIdAsync(Guid id);
    Task<UpdatedBookResponse> UpdateAsync(UpdateBookRequest updateBookRequest);
    Task<GetBookResponse> GetByIdAsync(Guid id);
}