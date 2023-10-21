using FoodSys.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FoodSys.Infra.IOC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config) 
        {
            services.AddDbContext<FoodSysDbContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("DataBase"), migration => migration.MigrationsAssembly(typeof(FoodSysDbContext).Assembly.FullName));
            });

            return services;
        }
    }
}
