using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSys.Domain.Entity
{
    [Table("CUSTOMER_PLAN")]
    public class CustomerPlan
    {
        public CustomerPlan()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        [Column("p_id")]
        public virtual Guid Id { get; set; }
        [Required]
        [Column("p_name")]
        [MaxLength(100)]
        public virtual String Name { get; set; }
    }
}
