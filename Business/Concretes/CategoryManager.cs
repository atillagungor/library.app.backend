using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.Category;
using Business.Dtos.Responses.Category;
using Business.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.DataAccess.Paging;
using Core.Utilities.Messages;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class CategoryManager : ICategoryService
{
    private readonly ICategoryDal _categoryDal;
    private readonly CategoryBusinessRules _categoryBusinessRules;
    private readonly IMapper _mapper;

    public CategoryManager(ICategoryDal categoryDal, CategoryBusinessRules categoryBusinessRules, IMapper mapper)
    {
        _categoryDal = categoryDal;
        _categoryBusinessRules = categoryBusinessRules;
        _mapper = mapper;
    }

    public async Task<CreatedCategoryResponse> AddAsync(CreateCategoryRequest createCategoryRequest)
    {
        await _categoryBusinessRules.CheckIfCategoryNameIsUniqueAsync(createCategoryRequest.Name);

        var category = _mapper.Map<Category>(createCategoryRequest);
        var addedCategory = await _categoryDal.AddAsync(category);

        return _mapper.Map<CreatedCategoryResponse>(addedCategory);
    }

    public async Task<IPaginate<GetListCategoryResponse>> GetListAsync(PageRequest pageRequest)
    {
        var categories = await _categoryDal.GetListAsync(
            predicate: null,
            orderBy: q => q.OrderBy(c => c.Name),
            include: null,
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize
        );

        var categoryResponses = _mapper.Map<List<GetListCategoryResponse>>(categories.Items);

        var totalCount = categories.Count;
        var totalPages = (int)Math.Ceiling((double)totalCount / pageRequest.PageSize);

        return new Paginate<GetListCategoryResponse>
        {
            Items = categoryResponses,
            Count = totalCount,
            Index = pageRequest.PageIndex,
            Size = pageRequest.PageSize,
            Pages = totalPages,
            From = pageRequest.PageIndex * pageRequest.PageSize
        };
    }

    public async Task<DeletedCategoryResponse> DeleteByIdAsync(Guid id)
    {
        await _categoryBusinessRules.CheckIfExistsById(id);

        var category = await _categoryDal.GetAsync(c => c.Id == id);
        if (category == null)
        {
            throw new BusinessException("Category not found.", BusinessCoreTitles.CannotFindError);
        }

        await _categoryDal.DeleteAsync(category);

        return new DeletedCategoryResponse
        {
            Id = id
        };
    }

    public async Task<UpdatedCategoryResponse> UpdateAsync(UpdateCategoryRequest updateCategoryRequest)
    {
        await _categoryBusinessRules.ValidateCategoryForUpdateAsync(updateCategoryRequest.Id, updateCategoryRequest.Name);

        var category = await _categoryDal.GetAsync(c => c.Id == updateCategoryRequest.Id);
        if (category == null)
        {
            throw new BusinessException("Category not found.", BusinessCoreTitles.CannotFindError);
        }

        _mapper.Map(updateCategoryRequest, category);

        var updatedCategory = await _categoryDal.UpdateAsync(category);

        return _mapper.Map<UpdatedCategoryResponse>(updatedCategory);
    }

    public async Task<GetCategoryResponse> GetByIdAsync(Guid id)
    {
        var category = await _categoryDal.GetAsync(c => c.Id == id);
        if (category == null)
        {
            throw new BusinessException("Category not found.", BusinessCoreTitles.CannotFindError);
        }

        return _mapper.Map<GetCategoryResponse>(category);
    }
}