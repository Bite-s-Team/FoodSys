using FoodSys.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodAPI.Data.Map
{
    public class CouponUserRelConfig : IEntityTypeConfiguration<CouponCustomerRel>
    {
        public void Configure(EntityTypeBuilder<CouponCustomerRel> builder)
        {
            builder.HasOne(x => x.Coupon).WithMany(x => x.CustomerRel).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.User).WithOne().OnDelete(DeleteBehavior.NoAction);
        }
    }
}
