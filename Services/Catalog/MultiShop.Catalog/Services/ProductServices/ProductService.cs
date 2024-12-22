using System;
using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices;

public class ProductService : IProductService
{
    private readonly IMongoCollection<Product> _productCollection;
    private readonly IMapper _mapper;

    public ProductService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
        _mapper = mapper;
    }

    public async Task CreateAsync(CreateProductDto createProductDto)
    {
        var value = _mapper.Map<Product>(createProductDto);
        await _productCollection.InsertOneAsync(value);
    }

    public async Task DeleteAsync(string id)
    {
        await _productCollection.DeleteOneAsync(x => x.Id == id);
    }

    public async Task<List<ResultProductDto>> GetAllAsync()
    {
        var values = await _productCollection.Find(_ => true).ToListAsync();
        return _mapper.Map<List<ResultProductDto>>(values);
    }

    public async Task<ResultProductDto> GetByIdAsync(string id)
    {
        var value = await _productCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        return _mapper.Map<ResultProductDto>(value);
    }

    public async Task UpdateAsync(UpdateProductDto updateProductDto)
    {
        var value = _mapper.Map<Product>(updateProductDto);
        await _productCollection.ReplaceOneAsync(x => x.Id == value.Id, value);
    }
}
