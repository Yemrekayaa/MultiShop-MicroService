using System;
using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices;

public class ProductImageService: IProductImageService
{
private readonly IMongoCollection<ProductImage> _ProductImageCollection;
    private readonly IMapper _mapper;

    public ProductImageService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _ProductImageCollection = database.GetCollection<ProductImage>(databaseSettings.ProductImageCollectionName);
        _mapper = mapper;
    }

    public async Task CreateAsync(CreateProductImageDto createProductImageDto)
    {
        var value = _mapper.Map<ProductImage>(createProductImageDto);
        await _ProductImageCollection.InsertOneAsync(value);
    }

    public async Task DeleteAsync(string id)
    {
        await _ProductImageCollection.DeleteOneAsync(x => x.Id == id);
    }

    public async Task<List<ResultProductImageDto>> GetAllAsync()
    {
        var values = await _ProductImageCollection.Find(_ => true).ToListAsync();
        return _mapper.Map<List<ResultProductImageDto>>(values);
    }

    public async Task<ResultProductImageDto> GetByIdAsync(string id)
    {
        var value = await _ProductImageCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        return _mapper.Map<ResultProductImageDto>(value);
    }

    public async Task UpdateAsync(UpdateProductImageDto updateProductImageDto)
    {
        var value = _mapper.Map<ProductImage>(updateProductImageDto);
        await _ProductImageCollection.ReplaceOneAsync(x => x.Id == value.Id, value);
    }
}
