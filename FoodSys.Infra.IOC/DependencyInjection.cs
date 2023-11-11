using FoodSys.Application.Map;
using FoodSys.Application.Service;
using FoodSys.Application.Service.Interface;
using FoodSys.Domain.Interface;
using FoodSys.Domain.Interface.Account;
using FoodSys.Infra.Data.Context;
using FoodSys.Infra.Data.Repository;
using FoodSys.Infra.Data.Repository.Account;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
            services.AddAutoMapper(typeof(EntityToDTOProfile));

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }
            ).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidIssuer = config["Jwt:issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(config["Jwt:secretKey"])),
                    ValidateAudience = true,
                    ValidAudience = config["Jwt:audience"],
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddScoped<ICustomerRepo, CustomerRepo>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IAuth, AuthCustomer>();

            return services;
        }
    }
}
