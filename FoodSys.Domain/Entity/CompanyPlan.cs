using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodSys.Domain.Entity
{
    [Table("COMPANY_PLAN")]
    public class CompanyPlan
    {
        [Key]
        [Column("cp_id")]
        public virtual int Id { get; set; }
        [Required]
        [Column("cp_name")]
        [MaxLength(100)]
        public virtual String Name { get; set; }
    }
}
