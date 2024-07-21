using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.Author;
using Business.Dtos.Responses.Author;
using Business.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.DataAccess.Paging;
using Core.Utilities.Messages;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class AuthorManager : IAuthorService
{
    private readonly IAuthorDal _authorDal;
    private readonly AuthorBusinessRule _authorBusinessRules;
    private readonly IMapper _mapper;

    public AuthorManager(IAuthorDal authorDal, AuthorBusinessRule authorBusinessRules, IMapper mapper)
    {
        _authorDal = authorDal;
        _authorBusinessRules = authorBusinessRules;
        _mapper = mapper;
    }

    public async Task<CreatedAuthorResponse> AddAsync(CreateAuthorRequest createAuthorRequest)
    {
        await _authorBusinessRules.CheckIfAuthorNameIsUniqueAsync(createAuthorRequest.Name);

        var author = _mapper.Map<Author>(createAuthorRequest);
        var addedAuthor = await _authorDal.AddAsync(author);

        return _mapper.Map<CreatedAuthorResponse>(addedAuthor);
    }

    public async Task<IPaginate<GetListAuthorResponse>> GetListAsync(PageRequest pageRequest)
    {
        var authors = await _authorDal.GetListAsync(
            predicate: null,
            orderBy: q => q.OrderBy(a => a.Name),
            include: null,
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize
        );

        var authorResponses = _mapper.Map<List<GetListAuthorResponse>>(authors.Items);

        var paginateResult = new Paginate<GetListAuthorResponse>
        {
            Items = authorResponses,
            Count = authors.Items.Count,
            Index = pageRequest.PageIndex,
            Size = pageRequest.PageSize,
            Pages = (int)Math.Ceiling((double)authors.Items.Count / pageRequest.PageSize)
        };

        return paginateResult;
    }

    public async Task<DeletedAuthorResponse> DeleteByIdAsync(Guid id)
    {
        await _authorBusinessRules.CheckIfExistsById(id);

        var author = await _authorDal.GetAsync(a => a.Id == id);
        if (author == null)
        {
            throw new BusinessException("Author not found.", BusinessCoreTitles.CannotFindError);
        }

        await _authorDal.DeleteAsync(author);

        return new DeletedAuthorResponse
        {
            Id = id
        };
    }

    public async Task<UpdatedAuthorResponse> UpdateAsync(UpdateAuthorRequest updateAuthorRequest)
    {
        await _authorBusinessRules.ValidateAuthorForUpdateAsync(updateAuthorRequest.Id, updateAuthorRequest.Name);

        var author = await _authorDal.GetAsync(a => a.Id == updateAuthorRequest.Id);
        if (author == null)
        {
            throw new BusinessException("Author not found.", BusinessCoreTitles.CannotFindError);
        }

        _mapper.Map(updateAuthorRequest, author);

        var updatedAuthor = await _authorDal.UpdateAsync(author);

        return _mapper.Map<UpdatedAuthorResponse>(updatedAuthor);
    }

    public async Task<GetAuthorResponse> GetByIdAsync(Guid id)
    {
        var author = await _authorDal.GetAsync(a => a.Id == id);
        if (author == null)
        {
            throw new BusinessException("Author not found.", BusinessCoreTitles.CannotFindError);
        }

        return _mapper.Map<GetAuthorResponse>(author);
    }
}