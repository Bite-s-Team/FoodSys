using FoodSys.Domain.Interface.Account;
using FoodSys.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FoodSys.Infra.Data.Repository.Account
{
    public class AuthCustomer : IAuth
    {
        private readonly FoodSysDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public AuthCustomer(FoodSysDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public string GenToken(Guid id, string email, string name)
        {
            var claims = new[]
            {
                new Claim("id", id.ToString()),
                new Claim("email", email),
                new Claim("name", name),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var privateKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"], 
                _configuration["Jwt:Audience"], 
                claims: claims, 
                expires: DateTime.Now.AddHours(8), 
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        public async Task<bool> Login(string email, string password)
        {
            var user = await _dbContext.Customer.FirstOrDefaultAsync(x => x.Email == email);

            if (user == null)
            {
                return false;
            }

            using var hmac = new System.Security.Cryptography.HMACSHA512(user.PasswordSalt);
            var computerHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computerHash.Length; i++)
            {
                if (computerHash[i] != user.PasswordHash[i])
                {
                    return false;
                }
            }

            return true;
        }

        public async Task<bool> UserExist(string email)
        {
            return await _dbContext.Customer.AnyAsync(x => x.Email == email);
        }
    }
}
