using System;
using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductDetailServices;

public class ProductDetailService : IProductDetailService
{
    private readonly IMongoCollection<ProductDetail> _ProductDetailCollection;
    private readonly IMapper _mapper;

    public ProductDetailService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _ProductDetailCollection = database.GetCollection<ProductDetail>(databaseSettings.ProductDetailCollectionName);
        _mapper = mapper;
    }

    public async Task CreateAsync(CreateProductDetailDto createProductDetailDto)
    {
        var value = _mapper.Map<ProductDetail>(createProductDetailDto);
        await _ProductDetailCollection.InsertOneAsync(value);
    }

    public async Task DeleteAsync(string id)
    {
        await _ProductDetailCollection.DeleteOneAsync(x => x.Id == id);
    }

    public async Task<List<ResultProductDetailDto>> GetAllAsync()
    {
        var values = await _ProductDetailCollection.Find(_ => true).ToListAsync();
        return _mapper.Map<List<ResultProductDetailDto>>(values);
    }

    public async Task<ResultProductDetailDto> GetByIdAsync(string id)
    {
        var value = await _ProductDetailCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        return _mapper.Map<ResultProductDetailDto>(value);
    }

    public async Task UpdateAsync(UpdateProductDetailDto updateProductDetailDto)
    {
        var value = _mapper.Map<ProductDetail>(updateProductDetailDto);
        await _ProductDetailCollection.ReplaceOneAsync(x => x.Id == value.Id, value);
    }
}
