using FoodSys.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodAPI.Data.Map
{
    public class CompanyConfig :IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasOne(x => x.Type).WithMany();
            builder.HasOne(x => x.Plan).WithMany();
            builder.Ignore(x => x.Error);
        }
        
    }
}
