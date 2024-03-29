﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodSys.Domain.Entity
{
    [Table("COMPANY")]
    public class Company
    {
        public Company()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        [Column("cy_id")]
        public virtual Guid? Id { get; set; }

        [Column("cy_name")]
        [Required]
        [MaxLength(255)]
        public virtual String Name { get; set; }

        [Column("cy_description")]
        [Required]
        [MaxLength(1000)]
        public virtual String Description { get; set; }

        [Column("cy_email")]
        [Required]
        [MaxLength(255)]
        public virtual String Email { get; set; }

        [Column("cy_password")]
        [Required]
        [MaxLength(60)]
        public virtual String Password { get; set; }

        [Column("cy_cnpj")]
        [Required]
        [MaxLength(14)]
        public virtual String CNPJ { get; set; }

        [Column("cy_type_id")]
        [Required]
        public virtual int TypeId { get; set; }
        public virtual CompanyType Type { get; set; }

        [Column("cy_plan_id")]
        [Required]
        public virtual int PlanId { get; set; }
        public virtual CompanyPlan Plan { get; set; }
    }
}
