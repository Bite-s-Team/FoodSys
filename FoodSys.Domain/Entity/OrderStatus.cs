using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodSys.Domain.Entity
{
    [Table("ORDER_STATUS")]
    public class OrderStatus
    {
        public OrderStatus() 
        { 
            Id = Guid.NewGuid();
        }
        [Key]
        [Column("os_id")]
        public virtual Guid Id { get; set; }
        [Required]
        [Column("os_name")]
        [MaxLength(100)]
        public virtual String Name { get; set; }
    }
}
