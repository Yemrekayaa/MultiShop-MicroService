using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BussinesLayer.Abstract
{
    public interface ICargoCustomerService : IGenericService<CargoCustomer>
    {
        CargoCustomer TGetCargoCustomerById(string id);
    }
}
