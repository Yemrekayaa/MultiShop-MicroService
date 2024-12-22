using System;
using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services;

public class DiscountService : IDiscountService
{
    private readonly DapperContext _context;

    public DiscountService(DapperContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(CreateCouponDto createCouponDto)
    {
        string query = "insert into Coupons (Code,Rate,IsActive,ValidDate) values (@code, @rate, @isActive, @validDate)";
        var parameters = new DynamicParameters();
        parameters.Add("@code", createCouponDto.Code);
        parameters.Add("@rate", createCouponDto.Rate);
        parameters.Add("@isActive", createCouponDto.IsActive);
        parameters.Add("@validDate", createCouponDto.ValidDate);
        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(query, parameters);
    }

    public async Task DeleteAsync(int id)
    {
        string query = "Delete from Coupons where Id=@id";
        var parameters = new DynamicParameters();
        parameters.Add("@id", id);
        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(query, parameters);
    }

    public async Task<List<ResultCouponDto>> GetAllAsync()
    {
        string query = "Select * from Coupons";
        using var connection = _context.CreateConnection();
        var values = await connection.QueryAsync<ResultCouponDto>(query);
        return values.ToList();
    }

    public async Task<ResultCouponDto> GetByIdAsync(int id)
    {
        string query = "Select * from Coupons where Id=@id";
        var parameters = new DynamicParameters();
        parameters.Add("@id", id);
        using var connection = _context.CreateConnection();
        var values = await connection.QueryFirstOrDefaultAsync<ResultCouponDto>(query, parameters);
        return values;
    }

    public async Task UpdateAsync(UpdateCouponDto updateCouponDto)
    {
        string query = "Update Coupons Set Code=@code, Rate=@rate, IsActive=@isActive, ValidDate=@validDate where Id=@id";
        var parameters = new DynamicParameters();
        parameters.Add("@code", updateCouponDto.Code);
        parameters.Add("@rate", updateCouponDto.Rate);
        parameters.Add("@isActive", updateCouponDto.IsActive);
        parameters.Add("@validDate", updateCouponDto.ValidDate);
        parameters.Add("@id", updateCouponDto.Id);

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(query, parameters);
    }
}
