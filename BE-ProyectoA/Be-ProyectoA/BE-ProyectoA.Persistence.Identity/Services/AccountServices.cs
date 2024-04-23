using BE_ProyectoA.Core.Application.Dtos.Users;
using BE_ProyectoA.Core.Application.Enums;
using BE_ProyectoA.Core.Application.Interfaces;
using BE_ProyectoA.Core.Application.Wrappers;
using BE_ProyectoA.Core.Domain.Settings;
using BE_ProyectoA.Persistence.Identity.Helpers;
using BE_ProyectoA.Persistence.Identity.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BE_ProyectoA.Persistence.Identity.Services
{
    public class AccountServices(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager, DateTime dateTime, IOptions<JWT> jwt) : IAccountServices
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly RoleManager<IdentityRole> _roleManager = roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager = signInManager;
        private readonly DateTime _dateTime = dateTime;
        private readonly JWT _jwt = jwt.Value;

        public async Task<Response<AuthenticationResponse>> AuthenticatedAsync(AuthenticationRequest request, string ipAddress)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new Exception($"No Existe un usuario registrado con este correo{request.Email}");
            }
            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                throw new Exception($"las crendenciales no son validas ${request.Email}");
            }

            JwtSecurityToken jwtSecurityToken = await GenerateJWToken(user);
            AuthenticationResponse response = new AuthenticationResponse();
            response.Id = user.Id;
            response.JWToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            response.Email = user.Email;
            response.UserName = user.UserName;

            var roleList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
            response.Roles = roleList.ToList();
            response.IsAuthenticated = user.EmailConfirmed;

            var refreshToken = GenerateRefreshToken(ipAddress);
            response.RefreshToken = refreshToken.Token;
            return new Response<AuthenticationResponse>(response, $"Usuario autenticado {user.UserName}");

        }

        public async Task<Response<string>> RegisterAsync(RegisterRequest request, string origin)
        {
            var isExistsUser = await _userManager.FindByNameAsync(request.UserName);
            if (isExistsUser != null)
            {
                throw new Exception($"El usuario {request.UserName} ya existe en el sistema");
            }
            var user = new ApplicationUser
            {
                Email = request.Email,
                UserName = request.UserName,
                Apellido = request.Apellido,
                Nombre = request.Nombre,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };

            var isExisteEmail = await _userManager.FindByEmailAsync(request.Email);
            if (isExisteEmail != null)
            {
                throw new Exception($"EL email {request.Email} ya fue registrado");
            }
            else
            {
                var result = await _userManager.CreateAsync(user, request.PassWord);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Roles.dirigente.ToString());
                    return new Response<string>(user.Id, message: $"Usuario Registrado Exitosamente. {request.UserName}");
                }
                else
                {
                    throw new Exception($"{result.Errors}");
                }
            }
        }

        private async Task<JwtSecurityToken> GenerateJWToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim("Roles", roles[i]));
            }

            string ipAdress = IpHelper.GetIpAdress();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim("uid",user.Id),
                new Claim("ip",ipAdress),


            }.Union(userClaims).Union(roleClaims);

            var symemtricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));

            var signingCredentials = new SigningCredentials(symemtricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken
                (
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwt.DurationInMinutes),
                signingCredentials: signingCredentials
                );

            return jwtSecurityToken;
        }

        private RefreshToken GenerateRefreshToken(string ipAddress)
        {
            return new RefreshToken
            {
                Token = RandomTokenString(),
                Expires = DateTime.Now.AddDays(1),
                Created = DateTime.Now,
                CreatedByIp = ipAddress
            };
        }
        private string RandomTokenString()
        {
            var randomNumber = new byte[40];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                string refreshToken = Convert.ToBase64String(randomNumber);
            }
            return BitConverter.ToString(randomNumber).Replace("-", "");
        }
    }
}
