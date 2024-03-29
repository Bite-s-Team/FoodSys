﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodSys.Domain.Entity
{
    [Table("COUPON")]
    public class Coupon
    {
        public Coupon()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        [Column("c_id")]
        public virtual Guid? Id { get; set; }

        [Column("c_code")]
        [Required]
        [MaxLength(30)]
        public virtual String Code { get; set; }

        [Column("c_name")]
        [Required]
        [MaxLength(255)]
        public virtual String Name { get; set; }

        [Column("c_description")]
        [Required]
        [MaxLength(1000)]
        public virtual String Description { get; set; }

        [Column("c_menu_id")]
        [Required]
        public virtual Guid? MenuID { get; set; }
        public virtual Menu? Menu { get; set; }

        [Column("c_value")]
        [Required]
        public virtual Decimal Value { get; set; }

        [Column("c_value_type_id")]
        [Required]
        public virtual int ValueTypeId { get; set; }
        public virtual CouponValueType ValueType { get; set; }

        [Column("c_company_type_id")]
        [Required]
        public virtual int CompanyTypeId { get; set; }
        public virtual CompanyType CompanyType { get; set; }

        [Column("c_plan_id")]
        [Required]
        public virtual int PlanId { get; set; }
        public virtual CustomerPlan Plan { get; set; }

        public virtual List<CouponCustomerRel>? CustomerRel { get; set; }
        public virtual List<CouponCompanyRel> CompanyRel { get; set; }
    }
}
