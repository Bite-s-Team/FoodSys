using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FoodSys.Domain.Entity
{
    [Table("COUPON_COSTUMER")]
    public class CouponCustomerRel
    {
        public CouponCustomerRel() 
        { 
            Id = Guid.NewGuid();
        }

        [Key]
        [Column("cct_id")]
        public virtual Guid? Id { get; set; }

        [Column("cct_coupon_id")]
        [Required]
        public virtual Guid CouponId { get; set; }
        [JsonIgnore]
        public virtual Coupon? Coupon { get; set; }

        [Column("cct_costumer_id")]
        [Required]
        public virtual Guid CustomerId { get; set; }
        [JsonIgnore]
        public virtual Customer? User { get; set;}
    }
}
