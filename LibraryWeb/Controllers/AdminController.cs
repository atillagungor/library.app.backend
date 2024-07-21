using Business.Abstracts;
using Business.Dtos.Requests.Admin;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateAdminRequest createAdminRequest)
        {
            var result = await _adminService.AddAsync(createAdminRequest);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = result.Id }, result);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
        {
            var result = await _adminService.GetListAsync(pageRequest);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                var result = await _adminService.GetByIdAsync(id);
                return Ok(result);
            }
            catch (BusinessException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateAdminRequest updateAdminRequest)
        {
            try
            {
                var result = await _adminService.UpdateAsync(updateAdminRequest);
                return Ok(result);
            }
            catch (BusinessException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteByIdAsync(Guid id)
        {
            try
            {
                var result = await _adminService.DeleteByIdAsync(id);
                return Ok(result);
            }
            catch (BusinessException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}