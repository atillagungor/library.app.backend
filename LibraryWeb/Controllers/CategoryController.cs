using Business.Abstracts;
using Business.Dtos.Requests.Category;
using Business.Dtos.Responses.Category;
using Core.Aspects.Autofac.SecuredOperation;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [SecuredOperation("admin")]
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCategoryRequest createCategoryRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var response = await _categoryService.AddAsync(createCategoryRequest);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpGet("getall")]
    public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
    {
        var response = await _categoryService.GetListAsync(pageRequest);
        return Ok(response);
    }

    [HttpGet("getbyid/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var response = await _categoryService.GetByIdAsync(id);
        return response != null ? Ok(response) : NotFound();
    }

    [SecuredOperation("admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            var response = await _categoryService.DeleteByIdAsync(id);
            return Ok(new { id = response.Id }); // Response olarak id döndürüyoruz
        }
        catch (BusinessException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [SecuredOperation("admin")]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCategoryRequest updateCategoryRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var response = await _categoryService.UpdateAsync(updateCategoryRequest);
        return Ok(response);
    }
}