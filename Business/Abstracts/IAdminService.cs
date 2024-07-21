using Business.Dtos.Requests.Admin;
using Business.Dtos.Responses.Admin;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IAdminService
{
    Task<CreatedAdminResponse> AddAsync(CreateAdminRequest createAdminRequest);
    Task<IPaginate<GetListAdminResponse>> GetListAsync(PageRequest pageRequest);
    Task<DeletedAdminResponse> DeleteByIdAsync(Guid id);
    Task<UpdatedAdminResponse> UpdateAsync(UpdateAdminRequest updateAdminRequest);
    Task<GetAdminResponse> GetByIdAsync(Guid id);
}