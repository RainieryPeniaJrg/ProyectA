using BE_ProyectoA.Core.Application.DTOs.Request.Account;
using BE_ProyectoA.Core.Application.DTOs.Response;
using BE_ProyectoA.Core.Application.DTOs.Response.Account;
using BE_ProyectoA.Core.Application.Interfaces;
using BE_ProyectoA.Core.Domain.Entities.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BE_ProyectoA.Persistence.Identity.Repos
{
    public class AccountRepository
        (
        RoleManager<IdentityRole> roleManager,
        UserManager<ApplicationUser> userManager, IConfiguration config,
        SignInManager<ApplicationUser> signInManager
        ) : IAccount
    {
        private async Task<ApplicationUser> FindUserByEmailAsync(string email) 
            => await userManager.FindByEmailAsync(email);

        private async Task<IdentityRole> FindByRoleNameAsync(string rolename)
            => await roleManager.FindByNameAsync(rolename);

        private static string GenerateRefreshToken()
            => Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

        private async Task<string> GenerateToken(ApplicationUser user)
        {
            try
            {

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:key"]!));
                var credentials =  new SigningCredentials (securityKey,SecurityAlgorithms.HmacSha256);
                var userClaims = new[]
                {
                    new Claim(ClaimTypes.Email,user.Email!),
                    new Claim(ClaimTypes.Name, user.Nombre!),
                    new Claim(ClaimTypes.Role, (await userManager.GetRolesAsync(user)).FirstOrDefault()!.ToString()),
                    new Claim ("FullName",user.Nombre!),
                };

                var token = new JwtSecurityToken
                    (
                     issuer: config["Jwt:Issuer"],
                     audience: config["Jwt:Audience"],
                     claims: userClaims,
                     expires: DateTime.Now.AddMinutes(30),
                     signingCredentials: credentials

                    );

                return new JwtSecurityTokenHandler().WriteToken(token);

            }
            catch
            {
                return null!;
            }
        }

        public Task<GeneralResponse> ChangeUserRoleAsync(CreateAccountDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse> CreateAccountAsync(CreateAccountDTO model)
        {
            throw new NotImplementedException();
        }

        public Task CreateAdmin()
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse> CreateRoleAsync(CreateRoleDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetRoleDTO>> GetRolesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetUsersWithRoleDTO>> GetUsersWithRolesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<LoginResponse> LoginAccountAsync(LoginDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
