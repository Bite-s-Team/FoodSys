﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodSys.Domain.Entity
{
    [Table("ADDRESS")]
    public class Address
    {
        public Address()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        [Column("a_id")]
        public virtual Guid? Id { get; set; }

        [Column("a_cep")]
        [Required]
        [MaxLength(8)]
        public virtual String CEP { get; set; }

        [Column("a_street")]
        [Required]
        [MaxLength(255)]
        public virtual String Street { get; set; }

        [Column("a_address_number")]
        [Required]
        public virtual int AddressNumber { get; set; }

        [Column("a_complement")]
        [MaxLength(255)]
        public virtual String? Complement { get; set; }

        [Column("a_receiver_name")]
        [Required]
        [MaxLength(255)]
        public virtual String ReceiverName { get; set; }

        [Column("a_costumer_id")]
        [Required]
        public virtual Guid CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
    }
}
