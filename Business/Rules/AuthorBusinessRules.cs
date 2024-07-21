using Core.Business.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using DataAccess.Abstracts;
using Entities.Concretes;
using Core.Utilities.Messages;

namespace Business.Rules
{
    public class AuthorBusinessRules : BaseBusinessRules<Author>
    {
        private readonly IAuthorDal _authorDal;

        public AuthorBusinessRules(IAuthorDal authorDal)
            : base(authorDal)
        {
            _authorDal = authorDal;
        }

        public async Task CheckIfAuthorNameIsUniqueAsync(string name)
        {
            var existingAuthor = await _authorDal.GetAsync(a => a.Name == name);
            if (existingAuthor != null)
            {
                throw new BusinessException("Author name must be unique.", BusinessCoreTitles.CannotFindError);
            }
        }

        public async Task ValidateAuthorForUpdateAsync(Guid authorId, string name)
        {
            var existingAuthor = await CheckIfExistsById(authorId);
            if (existingAuthor.Name != name)
            {
                await CheckIfAuthorNameIsUniqueAsync(name);
            }
        }
    }
}