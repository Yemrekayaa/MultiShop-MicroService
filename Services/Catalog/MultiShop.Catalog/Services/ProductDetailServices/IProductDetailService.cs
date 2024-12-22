using System;
using MultiShop.Catalog.Dtos.ProductDetailDtos;

namespace MultiShop.Catalog.Services.ProductDetailServices;

public interface IProductDetailService
{
    Task<List<ResultProductDetailDto>> GetAllAsync();
    Task CreateAsync(CreateProductDetailDto createProductDetailDto);
    Task UpdateAsync(UpdateProductDetailDto updateProductDetailDto);
    Task DeleteAsync(string id);
    Task<ResultProductDetailDto> GetByIdAsync(string id);
}
