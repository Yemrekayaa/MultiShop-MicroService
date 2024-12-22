using System;
using MultiShop.Catalog.Dtos.ProductImageDtos;

namespace MultiShop.Catalog.Services.ProductImageServices;

public interface IProductImageService
{
    Task<List<ResultProductImageDto>> GetAllAsync();
    Task CreateAsync(CreateProductImageDto createProductImageDto);
    Task UpdateAsync(UpdateProductImageDto updateProductImageDto);
    Task DeleteAsync(string id);
    Task<ResultProductImageDto> GetByIdAsync(string id);
}
