using System.ComponentModel;
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

        [Column("ct_password_hash")]
        [Required]
        public virtual byte[] PasswordHash { get; set; }

        [Column("ct_password_salt")]
        [Required]
        public virtual byte[] PasswordSalt { get; set; }

        [Column("ct_phonenumber")]
        [MaxLength(11)]
        public virtual String? PhoneNumber { get; set; }

        [Column("ct_birthday")]
        public virtual DateTime? Birthday { get; set; }

        [Column("ct_cpf")]
        [MaxLength(11)]
        public virtual String CPF { get; set; }

        [Column("ct_plan_id")]
        [DefaultValue(1)]
        public virtual int PlanId { get; set; }
        public virtual CustomerPlan Plan { get; set; }

        [Column("ct_active")]
        [DefaultValue(1)]
        [Required]
        public virtual bool Active { get; set; }
    }
}
