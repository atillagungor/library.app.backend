using Core.Business.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Messages;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Rules
{
    public class AdminBusinessRule : BaseBusinessRules<Admin>
    {
        private readonly IAdminDal _adminDal;

        public AdminBusinessRule(IAdminDal adminDal)
            : base(adminDal)
        {
            _adminDal = adminDal;
        }

        public async Task CheckIfEmailIsUniqueAsync(string email)
        {
            var admin = await _adminDal.GetAsync(a => a.Email == email);
            if (admin != null)
            {
                throw new BusinessException("Admin email must be unique.", BusinessCoreTitles.CannotFindError);
            }
        }

        public async Task ValidateAdminForUpdateAsync(Guid adminId, string email)
        {
            var existingAdmin = await CheckIfExistsById(adminId);
            if (existingAdmin.Email != email)
            {
                await CheckIfEmailIsUniqueAsync(email);
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
