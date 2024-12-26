using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiShop.Cargo.BusinessLayer.Concrete;
using MultiShop.Cargo.BussinesLayer.Abstract;
using MultiShop.Cargo.BussinesLayer.Concrete;

namespace MultiShop.Cargo.BussinesLayer
{
    public static class ServiceRegistiration
    {
        public static void AddBussinesLayerService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICargoCompanyService, CargoCompanyManager>();
            services.AddScoped<ICargoCustomerService, CargoCustomerManager>();
            services.AddScoped<ICargoDetailService, CargoDetailManager>();
            services.AddScoped<ICargoOperationService, CargoOperationManager>();

        }
    }
}
