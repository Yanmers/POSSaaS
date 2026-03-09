using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POSBackend.Services;
using POSShared.DTOs;

namespace POSBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorisController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategorisController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll()
        {
            var categoris = await _categoryService.GetAllAsync();
            return Ok(categoris);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound($"Please validate {id} notfound");
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> Create(CreateCategory request)
        {
            var category = await _categoryService.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryDto>> Update(int id, EditCategory request)
        {
            var category = await _categoryService.UpdateAsync(id, request);
            if (category == null)
            {
                return BadRequest($"Please validate {category}");
            }

            return Ok(request);
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return false;
            }
            return true;
        }



    }
}
