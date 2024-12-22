using System;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services;

public interface IDiscountService
{
    Task<List<ResultCouponDto>> GetAllAsync();
    Task CreateAsync(CreateCouponDto createCouponDto);
    Task UpdateAsync(UpdateCouponDto updateCouponDto);
    Task<ResultCouponDto> GetByIdAsync(int id);
    Task DeleteAsync(int id);
}
