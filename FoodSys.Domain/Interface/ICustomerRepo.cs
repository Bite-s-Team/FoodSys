using FoodSys.Domain.Entity;

namespace FoodSys.Domain.Interface
{
    public interface ICustomerRepo
    {
        Task<Customer> AddCustomer(Customer customer);
        Task<Customer> UpdateCustomer(Customer customer);
        Task<bool> DeleteCustomer(Guid customerId);
        Task<Customer> GetCustomer(Guid customerId);
    }
}
