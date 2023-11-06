using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodSys.Domain.Entity
{
    [Table("DELIVERER_VEHICLE")]
    public class DelivererVehicle
    {
        [Key]
        [Column("dv_id")]
        public virtual int Id { get; set; }
        [Column("dv_name")]
        [Required]
        [MaxLength(100)]
        public virtual String Name { get; set; }
    }
}
