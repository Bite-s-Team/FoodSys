using FoodSys.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodAPI.Data.Map
{
    public class CouponCompanyRelConfig : IEntityTypeConfiguration<CouponCompanyRel>
    {
        public void Configure(EntityTypeBuilder<CouponCompanyRel> builder)
        {
            builder.HasOne(x => x.Coupon).WithMany(x => x.CompanyRel).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Company).WithOne().OnDelete(DeleteBehavior.NoAction);
        }
    }
}
