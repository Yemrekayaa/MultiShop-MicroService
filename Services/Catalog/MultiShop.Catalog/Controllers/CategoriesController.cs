using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Services.CategoryServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _categoryService.GetAllAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto createCategoryDto)
        {
            await _categoryService.CreateAsync(createCategoryDto);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            await _categoryService.DeleteAsync(id);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryService.UpdateAsync(updateCategoryDto);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var value = await _categoryService.GetByIdAsync(id);
            return Ok(value);
        }
    }
}
