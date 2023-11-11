using FoodSys.Domain.Entity;

namespace FoodSys.Application.DTO.Response.Customer
{
    public class GetCustomerResponse
    {
        public virtual String? Name { get; set; }
        public virtual String? Email { get; set; }
        public virtual String? PhoneNumber { get; set; }
        public virtual DateTime? Birthday { get; set; }
        public virtual CustomerPlan? Plan { get; set; }
    }
}
