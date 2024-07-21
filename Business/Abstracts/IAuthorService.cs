using Business.Dtos.Requests.Author;
using Business.Dtos.Responses.Author;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IAuthorService
{
    Task<CreatedAuthorResponse> AddAsync(CreateAuthorRequest createAuthorRequest);
    Task<IPaginate<GetListAuthorResponse>> GetListAsync(PageRequest pageRequest);
    Task<DeletedAuthorResponse> DeleteByIdAsync(Guid id);
    Task<UpdatedAuthorResponse> UpdateAsync(UpdateAuthorRequest updateAuthorRequest);
    Task<GetAuthorResponse> GetByIdAsync(Guid id);
}