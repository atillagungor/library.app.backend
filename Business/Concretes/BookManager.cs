using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.Book;
using Business.Dtos.Responses.Book;
using Business.Rules;
using Core.Aspects.Autofac.SecuredOperation;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.DataAccess.Paging;
using Core.Utilities.Messages;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class BookManager : IBookService
{
    private readonly IBookDal _bookDal;
    private readonly BookBusinessRules _bookBusinessRules;
    private readonly IMapper _mapper;

    public BookManager(IBookDal bookDal, BookBusinessRules bookBusinessRules, IMapper mapper)
    {
        _bookDal = bookDal;
        _bookBusinessRules = bookBusinessRules;
        _mapper = mapper;
    }

    public async Task<CreatedBookResponse> AddAsync(CreateBookRequest createBookRequest)
    {
        await _bookBusinessRules.CheckIfBookNameIsUniqueAsync(createBookRequest.Name);

        var book = _mapper.Map<Book>(createBookRequest);
        var addedBook = await _bookDal.AddAsync(book);

        return _mapper.Map<CreatedBookResponse>(addedBook);
    }

    public async Task<IPaginate<GetListBookResponse>> GetListAsync(PageRequest pageRequest)
    {
        var books = await _bookDal.GetListAsync(
            predicate: null,
            orderBy: q => q.OrderBy(b => b.Name),
            include: b => b.Include(x => x.Author),
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize
        );

        var bookResponses = _mapper.Map<List<GetListBookResponse>>(books.Items);

        var totalCount = books.Count;
        var totalPages = (int)Math.Ceiling((double)totalCount / pageRequest.PageSize);

        return new Paginate<GetListBookResponse>
        {
            Items = bookResponses,
            Count = totalCount,
            Index = pageRequest.PageIndex,
            Size = pageRequest.PageSize,
            Pages = totalPages,
            From = pageRequest.PageIndex * pageRequest.PageSize
        };
    }

    public async Task<DeletedBookResponse> DeleteByIdAsync(Guid id)
    {
        var book = await _bookDal.GetAsync(b => b.Id == id);
        if (book == null)
        {
            throw new BusinessException("Book not found.", BusinessCoreTitles.CannotFindError);
        }

        await _bookDal.DeleteAsync(book);

        return new DeletedBookResponse
        {
            Id = book.Id
        };
    }

    [SecuredOperation("admin")]
    public async Task<UpdatedBookResponse> UpdateAsync(UpdateBookRequest updateBookRequest)
    {
        await _bookBusinessRules.ValidateBookForUpdateAsync(updateBookRequest.Id, updateBookRequest.Name);

        var book = await _bookDal.GetAsync(b => b.Id == updateBookRequest.Id);
        if (book == null)
        {
            throw new BusinessException("Book not found.", BusinessCoreTitles.CannotFindError);
        }

        _mapper.Map(updateBookRequest, book);

        var updatedBook = await _bookDal.UpdateAsync(book);

        return _mapper.Map<UpdatedBookResponse>(updatedBook);
    }

    public async Task<GetBookResponse> GetByIdAsync(Guid id)
    {
        var book = await _bookDal.GetAsync(b => b.Id == id);
        if (book == null)
        {
            throw new BusinessException("Book not found.", BusinessCoreTitles.CannotFindError);
        }

        return _mapper.Map<GetBookResponse>(book);
    }
}