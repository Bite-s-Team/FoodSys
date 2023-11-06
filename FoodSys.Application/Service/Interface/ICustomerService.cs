using FoodSys.Application.DTO.Request.Customer;
using FoodSys.Application.DTO.Response.Customer;

namespace FoodSys.Application.Service.Interface
{
    public interface ICustomerService
    {
        Task<AddCustomerResponse> AddCustomer(AddCustomerRequest customer);
        Task<UpdateCustomerResponse> UpdateCustomer(UpdateCustomerRequest customer);
        Task<bool> DeleteCustomer(Guid customerId);
        Task<GetCustomerResponse> GetCustomer(Guid customerId);
    }
}
