using AutoMapper;
using FoodSys.Application.DTO.Request.Customer;
using FoodSys.Application.DTO.Response.Customer;
using FoodSys.Application.Service.Interface;
using FoodSys.Domain.Entity;
using FoodSys.Domain.Interface;
using FoodSys.Domain.Interface.Account;
using FoodSys.Infra.Data.Repository.Account;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Cryptography;

namespace FoodSys.Application.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepo _customerRepo;
        private readonly IMapper _mapper;
        private readonly IServiceProvider _serviceProvider;
        private readonly IAuth _auth;

        public CustomerService(ICustomerRepo customerRepo, IMapper mapper, IServiceProvider serviceProvider)
        {
            _customerRepo = customerRepo;
            _mapper = mapper;
            _serviceProvider = serviceProvider;
            var service = _serviceProvider.GetServices<IAuth>();
            _auth = service.First(service => service.GetType() == typeof(AuthCustomer));
        }

        public async Task<AddCustomerResponse> AddCustomer(AddCustomerRequest customer)
        {
            var map = _mapper.Map<Customer>(customer);
            
            using (var hmac = new HMACSHA256())
            {
                map.PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(customer.Password));
                map.PasswordSalt = hmac.Key;
            }
            map.PlanId = 1;

            var addCustomer = await _customerRepo.AddCustomer(map);
            var response = _mapper.Map<AddCustomerResponse>(addCustomer);

            response.Token = _auth.GenToken((Guid)addCustomer.Id, addCustomer.Email, addCustomer.Name);

            return response;
        }

        public Task<bool> DeleteCustomer(Guid customerId)
        {
            return _customerRepo.DeleteCustomer(customerId);
        }

        public async Task<GetCustomerResponse> GetCustomer(Guid customerId)
        {
            var customer = await _customerRepo.GetCustomer(customerId);
            return _mapper.Map<GetCustomerResponse>(customer);
        }

        public async Task<UpdateCustomerResponse> UpdateCustomer(UpdateCustomerRequest customer)
        {
            var map = _mapper.Map<Customer>(customer);
            var response = await _customerRepo.UpdateCustomer(map);

            return _mapper.Map<UpdateCustomerResponse>(response);
        }
    }
}
