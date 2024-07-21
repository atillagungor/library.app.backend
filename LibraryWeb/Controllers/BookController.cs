using Business.Abstracts;
using Business.Dtos.Requests.Book;
using Core.Aspects.Autofac.SecuredOperation;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [SecuredOperation("admin")]
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBookRequest createBookRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var response = await _bookService.AddAsync(createBookRequest);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpGet("getall")]
    public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
    {
        var response = await _bookService.GetListAsync(pageRequest);
        return Ok(response);
    }

    [HttpGet("getbyid/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var response = await _bookService.GetByIdAsync(id);
        return response != null ? Ok(response) : NotFound();
    }

    [SecuredOperation("admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            var response = await _bookService.DeleteByIdAsync(id);
            return Ok(new { id = response.Id });
        }
        catch (BusinessException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [SecuredOperation("admin")]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBookRequest updateBookRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var response = await _bookService.UpdateAsync(updateBookRequest);
        return Ok(response);
    }
}