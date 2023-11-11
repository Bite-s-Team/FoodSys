using System.ComponentModel.DataAnnotations;

namespace FoodSys.Application.DTO.Request.Customer
{
    public class UpdateCustomerRequest
    {
        public virtual Guid Id { get; set; }
        [MaxLength(255)]
        public virtual String? Name { get; set; }
        [MaxLength(255)]
        public virtual String? Email { get; set; }
        public virtual String? Password { get; set; }
        [MaxLength(11)]
        public virtual String? PhoneNumber { get; set; }
        public virtual DateTime? Birthday { get; set; }
        public virtual Guid? PlanId { get; set; }
    }
}
