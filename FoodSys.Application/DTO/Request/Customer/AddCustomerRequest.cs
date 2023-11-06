using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodSys.Application.DTO.Request.Customer
{
    public class AddCustomerRequest
    {
        [Required]
        [MaxLength(255)]
        public virtual String Name { get; set; }
        [Required]
        [MaxLength(255)]
        public virtual String Email { get; set; }
        [Required]
        [MaxLength(60)]
        [NotMapped]
        public virtual String Password { get; set; }
        [Required]
        [MaxLength(11)]
        public virtual String CPF { get; set; }
    }
}
