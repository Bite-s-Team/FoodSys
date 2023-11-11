using FoodSys.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodAPI.Data.Map
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(x => x.Customer).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Address);
            builder.HasOne(x => x.Deliverer);
            builder.HasOne(x => x.Company);
            builder.HasOne(x => x.Coupon);
            builder.HasMany(x => x.Itens).WithOne(x => x.Order).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
