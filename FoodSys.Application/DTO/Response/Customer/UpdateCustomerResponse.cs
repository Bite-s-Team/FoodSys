namespace FoodSys.Application.DTO.Response.Customer
{
    public class UpdateCustomerResponse
    {
        public virtual Guid Id { get; set; }
        public virtual String? Name { get; set; }
        public virtual String? Email { get; set; }
        public virtual String? PhoneNumber { get; set; }
        public virtual DateTime? Birthday { get; set; }
        public virtual Guid? PlanId { get; set; }
    }
}
