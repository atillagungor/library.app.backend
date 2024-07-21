using Core.Business.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Messages;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;

namespace Business.Rules
{
    public class CategoryBusinessRules : BaseBusinessRules<Category>
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryBusinessRules(ICategoryDal categoryDal)
            : base(categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public async Task CheckIfCategoryNameIsUniqueAsync(string categoryName)
        {
            var existingCategory = await _categoryDal.GetAsync(c => c.Name == categoryName);
            if (existingCategory != null)
            {
                throw new BusinessException(
                    "Category name must be unique.",
                    BusinessCoreTitles.CannotFindError,
                    StatusCodes.Status400BadRequest
                );
            }
        }

        public async Task ValidateCategoryForUpdateAsync(Guid categoryId, string categoryName)
        {
            var existingCategory = await CheckIfExistsById(categoryId);
            if (existingCategory.Name != categoryName)
            {
                await CheckIfCategoryNameIsUniqueAsync(categoryName);
            }
        }
    }
}
