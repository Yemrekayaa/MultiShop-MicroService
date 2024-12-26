using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Services.ProductServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _ProductService;

        public ProductsController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _ProductService.GetAllAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto createProductDto)
        {
            await _ProductService.CreateAsync(createProductDto);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            await _ProductService.DeleteAsync(id);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductDto updateProductDto)
        {
            await _ProductService.UpdateAsync(updateProductDto);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var value = await _ProductService.GetByIdAsync(id);
            return Ok(value);
        }
    }
}
