using System;
using MultiShop.Catalog.Dtos.CategoryDtos;

namespace MultiShop.Catalog.Services.CategoryServices;

public interface ICategoryService
{
    Task<List<ResultCategoryDto>> GetAllAsync();
    Task CreateAsync(CreateCategoryDto createCategoryDto);
    Task UpdateAsync(UpdateCategoryDto updateCategoryDto);
    Task DeleteAsync(string id);
    Task<ResultCategoryDto> GetByIdAsync(string id);
}
