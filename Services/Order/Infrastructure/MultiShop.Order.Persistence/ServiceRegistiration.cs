using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Persistence.Context;
using MultiShop.Order.Persistence.Repositories;

namespace MultiShop.Order.Persistence;

public static class ServiceRegistiration
{
    public static void AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddDbContext<OrderContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        //services.AddScoped<OrderContext>();

    }
}
