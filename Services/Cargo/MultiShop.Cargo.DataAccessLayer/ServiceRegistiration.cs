using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using MultiShop.Cargo.DataAccessLayer.EntityFramework;

namespace MultiShop.Cargo.DataAccessLayer
{
    public static class ServiceRegistiration
    {
        public static void AddDataAccessLayerService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CargoContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<ICargoCompanyDal, EfCargoCompanyDal>();
            services.AddScoped<ICargoCustomerDal, EfCargoCustomerDal>();
            services.AddScoped<ICargoDetailDal, EfCargoDetailDal>();
            services.AddScoped<ICargoOperationDal, EfCargoOperationDal>();

        }
    }
}
