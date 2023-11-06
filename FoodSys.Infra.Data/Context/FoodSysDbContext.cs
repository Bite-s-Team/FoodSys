using FoodSys.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace FoodSys.Infra.Data.Context
{
    public class FoodSysDbContext : DbContext
    {
        public FoodSysDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Address> Address { get; set; }
        public DbSet<Coupon> Coupon { get; set; }
        public DbSet<CouponCustomerRel> CouponCustomerRel { get; set; }
        public DbSet<CouponCompanyRel> CouponCompanyRel { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Deliverer> Deliverer { get; set; }
        public DbSet<DelivererMotorcicle> DelivererMotorcicle { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Item> OrderItens { get; set; }
        public DbSet<DelivererStatus> DelivererStatus { get; set; }
        public DbSet<DelivererVehicle> DelivererVehicle { get; set; }
        public DbSet<CompanyPlan> CompanyPlan { get; set; }
        public DbSet<CompanyType> CompanyType { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<CustomerPlan> CostumerPlan { get; set; }
        public DbSet<CouponValueType> CouponValueType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FoodSysDbContext).Assembly);

            base.OnModelCreating(modelBuilder);

            Seed(modelBuilder);
        }

        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DelivererStatus>().HasData(
                new DelivererStatus { Id = 1, Name = "Offline" },
                new DelivererStatus { Id = 2, Name = "Online" },
                new DelivererStatus { Id = 3, Name = "Work" }
                );
            modelBuilder.Entity<DelivererVehicle>().HasData(
                new DelivererVehicle { Id = 1, Name = "Bike" },
                new DelivererVehicle { Id = 2, Name = "Motorcicle" }
                );
            modelBuilder.Entity<CompanyPlan>().HasData(
                new CompanyPlan { Id = 1, Name = "Basic" },
                new CompanyPlan { Id = 2, Name = "Master" }
                );
            modelBuilder.Entity<CompanyType>().HasData(
                new CompanyType { Id = 1, Name = "Market" },
                new CompanyType { Id = 2, Name = "Restaurant" }
                );
            modelBuilder.Entity<OrderStatus>().HasData(
                new OrderStatus { Id = 1, Name = "Open" },
                new OrderStatus { Id = 2, Name = "Closed" },
                new OrderStatus { Id = 3, Name = "Canceled" }
                );
            modelBuilder.Entity<CustomerPlan>().HasData(
                new CustomerPlan { Id = 1, Name = "None" },
                new CustomerPlan { Id = 2, Name = "Premium" }
                );
            modelBuilder.Entity<CouponValueType>().HasData(
                new CouponValueType { Id = 1, Name = "Percetage" },
                new CouponValueType { Id = 2, Name = "Value" }
                );
        }
    }
}
