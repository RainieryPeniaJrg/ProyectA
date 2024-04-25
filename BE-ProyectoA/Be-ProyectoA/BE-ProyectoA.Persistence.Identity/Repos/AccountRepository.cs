using BE_ProyectoA.Core.Application.DTOs.Request.Account;
using BE_ProyectoA.Core.Application.DTOs.Response;
using BE_ProyectoA.Core.Application.DTOs.Response.Account;
using BE_ProyectoA.Core.Application.Extensions;
using BE_ProyectoA.Core.Application.Interfaces;
using BE_ProyectoA.Core.Domain.Entities.Authentication;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Constant = BE_ProyectoA.Core.Application.Extensions.Constant;

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

        private async Task<GeneralResponse> AssignUserToRole(ApplicationUser user, IdentityRole role)
        {

            if(user is null || role is null)return new GeneralResponse(false,"Model stato cannot be empty");

            if (await FindByRoleNameAsync(role.Name!) == null)
                await CreateRoleAsync(role.Adapt(new CreateRoleDTO()));

            IdentityResult result = await userManager.AddToRoleAsync(user, role.Name!);

            string error = CheckResponse(result);

            if (!string.IsNullOrEmpty(error))
                return new GeneralResponse(false, error);
            else
                return new GeneralResponse(true, $"{user.Nombre} assigned to {role.Name} role");

        }

        private static string CheckResponse(IdentityResult result)
        {
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(_ => _.Description);
                return string.Join(Environment.NewLine, errors);
            }
            return null!;
        }

        public Task<GeneralResponse> ChangeUserRoleAsync(CreateAccountDTO model)
        {
            throw new NotImplementedException();
        }

        public async Task<GeneralResponse> CreateAccountAsync(CreateAccountDTO model)
        {
            try
            {

                if (await FindUserByEmailAsync(model.Email) != null)
                    return new GeneralResponse(false, "Lo sentimos, el usuario ya ha sido creado");

                var user = new ApplicationUser()
                {
                    Email = model.Email,
                    UserName = model.Email,
                    Nombre = model.Nombre,
                    PasswordHash = model.Password
                };
                var result = await userManager.CreateAsync(user, model.Password);

                string error = CheckResponse(result);
                if (!string.IsNullOrEmpty(error)) return new GeneralResponse(false, error);

                var (flag,message) = await AssignUserToRole(user, new IdentityRole() { Name = model.Role });
                return new GeneralResponse(flag, message);
                
            }catch(Exception ex)
            {

                return new GeneralResponse(false, ex.Message);
            }
        }

        public async Task CreateAdmin()
        {
            try
            {
                if ((await FindUserByEmailAsync(Constant.Role.Admin)) == null) return;

                var admin = new CreateAccountDTO()
                {
                    Nombre = "Admin",
                    Password = "Admin@123",
                    Email = "admin@admin.com",
                    Role = Constant.Role.Admin
                };
                await CreateAccountAsync(admin);
            }catch { }
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

        public async Task<LoginResponse> LoginAccountAsync(LoginDTO model)
        {
            try
            {
                var user = await FindUserByEmailAsync(model.Email);

                if (user is null)
                    return new LoginResponse(false, "usuario no encontrado");

                SignInResult result;

                try
                {
                    result = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);
                }
                catch
                {
                    return new LoginResponse(false, "Credenciales Erroneas, intente de nuevo");
                }
                if (!result.Succeeded)
                    return new LoginResponse(false, "Credenciales Erroneas, intente de nuevo");

                string jwtToken = await GenerateToken(user);
                string refreshToken = GenerateRefreshToken();

                if (string.IsNullOrEmpty(jwtToken) || string.IsNullOrEmpty(refreshToken))
                    return new LoginResponse(false, "Error ocurrido mientras inicia sesion, favor contacta con el adiministrador");
                else
                    return new LoginResponse(true,$"{user.Nombre} ha iniciado sesion correctamente",jwtToken,refreshToken);

            }
            catch (Exception ex)
            {
                return new LoginResponse(false,ex.Message);
            }
        }

        public Task<LoginResponse> RefreshTokenAsync(RefreshTokenDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
