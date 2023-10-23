using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodSys.Domain.Entity
{
    [Table("COMPANY_TYPE")]
    public class CompanyType
    {
        public CompanyType() 
        { 
            Id = Guid.NewGuid();
        }
        [Key]
        [Column("ctp_id")]
        public virtual Guid Id { get; set; }
        [Required]
        [Column("ctp_name")]
        [MaxLength(100)]
        public virtual String Name { get; set; }
    }
}
