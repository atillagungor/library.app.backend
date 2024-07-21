using Business.Abstracts;
using Business.Dtos.Requests.Author;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAuthorRequest createAuthorRequest)
    {
        if (createAuthorRequest == null)
        {
            return BadRequest("Invalid author data.");
        }

        var response = await _authorService.AddAsync(createAuthorRequest);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var response = await _authorService.GetByIdAsync(id);

        if (response == null)
        {
            return NotFound("Author not found.");
        }

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        var response = await _authorService.GetListAsync(pageRequest);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAuthorRequest updateAuthorRequest)
    {
        if (updateAuthorRequest == null)
        {
            return BadRequest("Invalid author data.");
        }

        var response = await _authorService.UpdateAsync(updateAuthorRequest);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await _authorService.DeleteByIdAsync(id);

        if (response == null)
        {
            return NotFound("Author not found.");
        }

        return Ok(response);
    }
}