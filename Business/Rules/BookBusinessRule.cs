using Core.Business.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Messages;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;

namespace Business.Rules
{
    public class BookBusinessRules : BaseBusinessRules<Book>
    {
        private readonly IBookDal _bookDal;

        public BookBusinessRules(IBookDal bookDal)
            : base(bookDal)
        {
            _bookDal = bookDal;
        }
        public async Task CheckIfBookNameIsUniqueAsync(string bookName)
        {
            var existingBook = await _bookDal.GetAsync(b => b.Name == bookName);
            if (existingBook != null)
            {
                throw new BusinessException(
                    "Book name must be unique.",
                    BusinessCoreTitles.CannotFindError,
                    StatusCodes.Status400BadRequest
                );
            }
        }
        public async Task ValidateBookForUpdateAsync(Guid bookId, string bookName)
        {
            var existingBook = await CheckIfExistsById(bookId);
            if (existingBook.Name != bookName)
            {
                await CheckIfBookNameIsUniqueAsync(bookName);
            }
        }
    }
}