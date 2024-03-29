using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodSys.Domain.Entity
{
    [Table("DELIVERER_MOTORCICLE")]
    public class DelivererMotorcicle
    {
        public DelivererMotorcicle()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        [Column("dm_id")]
        public virtual Guid? Id { get; set; }

        [Column("dm_plate")]
        [Required]
        [StringLength(7)]
        public virtual String Plate { get; set; }

        [Column("dm_renavam")]
        [Required]
        [StringLength(9)]
        public virtual String Renavam { get; set; }

        [Column("dm_model")]
        [Required]
        [MaxLength(100)]
        public virtual String Model { get; set; }

        [Column("dm_year")]
        [Required]
        public virtual int Year { get; set; }

        [Column("dm_brand")]
        [Required]
        [MaxLength(100)]
        public virtual String Brand { get; set; }

        [Column("dm_deliverer_id")]
        [Required]
        public virtual Guid DelivererId { get; set; }
        public virtual Deliverer Deliverer { get; set; } 
    }
}