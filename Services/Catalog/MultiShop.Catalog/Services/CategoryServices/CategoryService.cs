using System;
using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.CategoryServices;

public class CategoryService : ICategoryService
{
    private readonly IMongoCollection<Category> _categoryCollection;
    private readonly IMapper _mapper;

    public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
        _mapper = mapper;
    }

    public async Task CreateAsync(CreateCategoryDto createCategoryDto)
    {
        var value = _mapper.Map<Category>(createCategoryDto);
        await _categoryCollection.InsertOneAsync(value);
    }

    public async Task DeleteAsync(string id)
    {
        await _categoryCollection.DeleteOneAsync(x => x.Id == id);
    }

    public async Task<List<ResultCategoryDto>> GetAllAsync()
    {
        var values = await _categoryCollection.Find(_ => true).ToListAsync();
        return _mapper.Map<List<ResultCategoryDto>>(values);
    }

    public async Task<ResultCategoryDto> GetByIdAsync(string id)
    {
        var value = await _categoryCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        return _mapper.Map<ResultCategoryDto>(value);
    }

    public async Task UpdateAsync(UpdateCategoryDto updateCategoryDto)
    {
        var value = _mapper.Map<Category>(updateCategoryDto);
        await _categoryCollection.ReplaceOneAsync(x => x.Id == value.Id, value);
    }
}
