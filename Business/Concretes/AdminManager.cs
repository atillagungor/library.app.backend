using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.Admin;
using Business.Dtos.Responses.Admin;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Messages;

namespace Business.Concretes;

public class AdminManager : IAdminService
{
    private readonly IAdminDal _adminDal;
    private readonly IRoleDal _roleDal;
    private readonly AdminBusinessRules _adminBusinessRules;
    private readonly IMapper _mapper;

    public AdminManager(IAdminDal adminDal, IRoleDal roleDal, AdminBusinessRules adminBusinessRules, IMapper mapper)
    {
        _adminDal = adminDal;
        _roleDal = roleDal;
        _adminBusinessRules = adminBusinessRules;
        _mapper = mapper;
    }

    public async Task<CreatedAdminResponse> AddAsync(CreateAdminRequest createAdminRequest)
    {
        await _adminBusinessRules.CheckIfRoleExistsAsync(createAdminRequest.RoleId);
        await _adminBusinessRules.CheckIfUsernameIsUniqueAsync(createAdminRequest.Username);
        _adminBusinessRules.ValidatePasswordHash(createAdminRequest.PasswordHash);

        var admin = _mapper.Map<Admin>(createAdminRequest);
        var createdAdmin = await _adminDal.AddAsync(admin);
        var response = _mapper.Map<CreatedAdminResponse>(createdAdmin);

        return response;
    }

    public async Task<IPaginate<GetListAdminResponse>> GetListAsync(PageRequest pageRequest)
    {
        var admins = await _adminDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize
        );

        var response = _mapper.Map<IPaginate<GetListAdminResponse>>(admins);

        return response;
    }

    public async Task<DeletedAdminResponse> DeleteByIdAsync(Guid id)
    {
        await _adminBusinessRules.CheckIfExistsById(id);

        var admin = await _adminDal.GetAsync(a => a.Id == id);
        if (admin == null)
        {
            throw new BusinessException("Admin not found.", BusinessCoreTitles.CannotFindError);
        }

        var deletedAdmin = await _adminDal.DeleteAsync(admin);
        var response = _mapper.Map<DeletedAdminResponse>(deletedAdmin);

        return response;
    }

    public async Task<UpdatedAdminResponse> UpdateAsync(UpdateAdminRequest updateAdminRequest)
    {
        await _adminBusinessRules.ValidateAdminForUpdateAsync(updateAdminRequest.Id, updateAdminRequest.Username);
        _adminBusinessRules.ValidatePasswordHash(updateAdminRequest.PasswordHash);

        var admin = _mapper.Map<Admin>(updateAdminRequest);
        var updatedAdmin = await _adminDal.UpdateAsync(admin);
        var response = _mapper.Map<UpdatedAdminResponse>(updatedAdmin);

        return response;
    }

    public async Task<GetAdminResponse> GetByIdAsync(Guid id)
    {
        var admin = await _adminDal.GetAsync(a => a.Id == id);
        if (admin == null)
        {
            throw new BusinessException("Admin not found.", BusinessCoreTitles.CannotFindError);
        }

        var response = _mapper.Map<GetAdminResponse>(admin);

        return response;
    }
}