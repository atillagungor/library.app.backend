using Core.Business.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Messages;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Rules
{
    public class AdminBusinessRules : BaseBusinessRules<Admin>
    {
        private readonly IRoleDal _roleDal;
        private readonly IAdminDal _adminDal;

        public AdminBusinessRules(IAdminDal adminDal, IRoleDal roleDal)
            : base(adminDal)
        {
            _roleDal = roleDal;
            _adminDal = adminDal;
        }

        public async Task CheckIfRoleExistsAsync(Guid roleId)
        {
            var roleExists = await _roleDal.GetAsync(r => r.Id == roleId);
            if (roleExists == null)
            {
                throw new BusinessException("The role ID is not valid.", BusinessCoreTitles.CannotFindError);
            }
        }

        public async Task CheckIfUsernameIsUniqueAsync(string username)
        {
            var admin = await _adminDal.GetAsync(a => a.Username == username);
            if (admin != null)
            {
                throw new BusinessException("Admin username must be unique.", BusinessCoreTitles.CannotFindError);
            }
        }

        public async Task ValidateAdminForUpdateAsync(Guid adminId, string username)
        {
            var existingAdmin = await CheckIfExistsById(adminId);
            if (existingAdmin.Username != username)
            {
                await CheckIfUsernameIsUniqueAsync(username);
            }
        }

        public void ValidatePasswordHash(string passwordHash)
        {
            if (string.IsNullOrWhiteSpace(passwordHash))
            {
                throw new BusinessException("Password hash cannot be empty.", BusinessCoreMessages.AccessDenied);
            }
        }
    }
}