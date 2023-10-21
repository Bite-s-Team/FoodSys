using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodSys.Domain.Entity
{
    [Table("CUSTOMER")]
    public class Customer
    {
        public Customer()
        {
            Id = Guid.NewGuid();
        }

        [Column("ct_id")]
        [Key]
        public virtual Guid? Id { get; set; }

        [Column("ct_name")]
        [Required]
        [MaxLength(255)]
        public virtual String Name { get; set; }

        [Column("ct_email")]
        [Required]
        [MaxLength(255)]
        public virtual String Email { get; set; }

        [Column("ct_password")]
        [Required]
        [MaxLength(60)]
        public virtual String Password { get; set; }

        [Column("ct_phonenumber")]
        [Required]
        [MaxLength(11)]
        public virtual String PhoneNumber { get; set; }

        [Column("ct_birthday")]
        [Required]
        public virtual DateTime Birthday { get; set; }

        [Column("ct_cpf")]
        [Required]
        [MaxLength(11)]
        public virtual String CPF { get; set; }

        [Column("ct_plan_id")]
        [Required]
        public virtual Guid PlanId { get; set; }
        public virtual CustomerPlan Plan { get; set; }
        public virtual String? Error { get; set; }
    }
}
