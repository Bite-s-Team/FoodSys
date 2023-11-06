using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodSys.Domain.Entity
{
    [Table("DELIVERER_STATUS")]
    public class DelivererStatus
    {
        [Key]
        [Column("ds_id")]
        public virtual int Id { get; set; }
        [Column("ds_name")]
        [Required]
        [MaxLength(100)]
        public virtual String Name { get; set; }
    }
}
