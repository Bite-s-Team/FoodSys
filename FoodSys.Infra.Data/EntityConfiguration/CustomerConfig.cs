using FoodSys.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodAPI.Data.Map
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        { 
            builder.HasOne(x => x.Plan).WithOne().OnDelete(DeleteBehavior.NoAction);
        }
        
    }
}
