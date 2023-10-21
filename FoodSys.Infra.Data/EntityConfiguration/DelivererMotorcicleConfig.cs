using FoodSys.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace FoodAPI.Data.Map
{
    public class DelivererMotorcicleConfig : IEntityTypeConfiguration<DelivererMotorcicle>
    {
        public void Configure (EntityTypeBuilder<DelivererMotorcicle> builder){
            builder.HasOne(x => x.Deliverer).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.Ignore(x => x.Error);
        }
        
    }
} 