using Business.Dtos.Requests.Role;
using Business.Dtos.Responses.Role;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IRoleService
{
    Task<CreatedRoleResponse> AddAsync(CreateRoleRequest createRoleRequest);
    Task<IPaginate<GetListRoleResponse>> GetListAsync(PageRequest pageRequest);
    Task<DeletedRoleResponse> DeleteByIdAsync(Guid id);
    Task<UpdatedRoleResponse> UpdateAsync(UpdateRoleRequest updateRoleRequest);
    Task<GetRoleResponse> GetByIdAsync(Guid id);
}