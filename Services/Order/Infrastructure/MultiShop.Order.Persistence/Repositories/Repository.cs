using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Persistence.Context;

namespace MultiShop.Order.Persistence.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly OrderContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(OrderContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task CreateAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var value = await _dbSet.FindAsync(id);
        _dbSet.Remove(value);
        await _context.SaveChangesAsync();
    }

    public async Task<List<T>> GetAllAsync()
    {
        var values = await _dbSet.ToListAsync();
        return values;
    }

    public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter)
    {
        var value = await _dbSet.SingleOrDefaultAsync(filter);
        return value;
    }

    public async Task<T> GetByIdAsync(int id)
    {
        var value = await _dbSet.FindAsync(id);
        return value;
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }
}
