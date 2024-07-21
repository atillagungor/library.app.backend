using Business.Dtos.Requests.User;
using Business.Dtos.Responses.User;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Abstracts;

public interface IUserService
{
    Task<CreatedUserResponse> AddAsync(CreateUserRequest createUserRequest);
    Task<IPaginate<GetListUserResponse>> GetListAsync(PageRequest pageRequest);
    Task<DeletedUserResponse> DeleteByIdAsync(Guid id);
    Task<DeletedUserResponse> DeleteByEmailAsync(string email);
    Task<UpdatedUserResponse> UpdateAsync(UpdateUserRequest updateUserRequest);
    Task<GetUserResponse> GetByIdAsync(Guid id);
    Task<User> GetByEmailAsync(string email, bool withDeleted);
}