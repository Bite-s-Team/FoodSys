using FoodSys.Domain.Entity;
using FoodSys.Domain.Interface;
using FoodSys.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FoodSys.Infra.Data.Repository
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly FoodSysDbContext _dbContext;

        public CustomerRepo(FoodSysDbContext dbContext) { 
            _dbContext = dbContext; 
        }
        public async Task<Customer> AddCustomer(Customer customer)
        {
            await _dbContext.Customer.AddAsync(customer);
            await _dbContext.SaveChangesAsync();

            return customer;
        }

        public async Task<bool> DeleteCustomer(Guid customerId)
        {
            var customer = await GetCustomer(customerId);

            if(customer == null)
            {
                return false;
            }

            customer.Active = false;
            _dbContext.Customer.Update(customer);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Customer> GetCustomer(Guid customerId)
        {
            return await _dbContext.Customer.Where(x => x.Id == customerId).Include(x => x.Plan).FirstOrDefaultAsync();
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            _dbContext.Customer.Update(customer);
            await _dbContext.SaveChangesAsync();
            return customer;
        }
    }
}
