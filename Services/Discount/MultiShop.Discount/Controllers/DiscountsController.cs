using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCouponList()
        {
            var values = await _discountService.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCouponById(int id)
        {
            var values = await _discountService.GetByIdAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoupon(CreateCouponDto createCouponDto)
        {
            await _discountService.CreateAsync(createCouponDto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCoupon(UpdateCouponDto updateCouponDto)
        {
            await _discountService.UpdateAsync(updateCouponDto);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCoupon(int id)
        {
            await _discountService.DeleteAsync(id);
            return Ok();
        }
    }
}
