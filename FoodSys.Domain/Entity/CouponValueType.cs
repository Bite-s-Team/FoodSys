using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodSys.Domain.Entity
{
    [Table("COUPON_VALUE_TYPE")]
    public class CouponValueType
    {
        public CouponValueType()
        {
            Id = Guid.NewGuid();
        }
        [Column("cvt_id")]
        [Key]
        public virtual Guid Id { get; set; }
        [Column("cvt_name")]
        [Required]
        [MaxLength(100)]
        public virtual String Name { get; set; }
    }
}
